using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Query.Application.Categories.QueryResult;
using Query.Application.Categories.Repository;

namespace Query.Persistence.CategoryConfigs.Repository;

public class CategoryQueryRepository : ICategoryQueryRepository
{
    private readonly string? _connectionString;

    public CategoryQueryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }

    private IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);

    public async Task<CategoryQr?> GetById(long id, CancellationToken ct)
    {
        const string sql = @"SELECT id, title, content, created_at 
                             FROM category 
                             WHERE id = @Id";

        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CategoryQr>(sql, new { Id = id });
    }

    public async Task<IEnumerable<CategoryQr>> GetAll()
    {
        const string sql = @"SELECT id, title, content, created_at 
                             FROM category 
                             ORDER BY created_at DESC";

        using var connection = CreateConnection();
        return await connection.QueryAsync<CategoryQr>(sql);
    }

    public async Task<(IEnumerable<CategoryQr> Items, int TotalCount)> SearchPagedAsync(string searchTerm,
        int pageNumber, int pageSize)
    {
        const string sqlData = @"SELECT id, title, content, created_at 
                                 FROM category 
                                 WHERE title ILIKE @Search OR content ILIKE @Search
                                 ORDER BY created_at DESC 
                                 OFFSET @Offset LIMIT @PageSize";

        const string sqlCount = @"SELECT COUNT(*) 
                                  FROM category 
                                  WHERE title ILIKE @Search OR content ILIKE @Search";

        using var connection = CreateConnection();

        var param = new
        {
            Search = $"%{searchTerm}%",
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize
        };

        var items = await connection.QueryAsync<CategoryQr>(sqlData, param);
        var totalCount = await connection.ExecuteScalarAsync<int>(sqlCount, param);

        return (items, totalCount);
    }
}