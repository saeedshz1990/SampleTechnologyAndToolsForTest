using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Query.Application.Articles.QueryResult;
using Query.Application.Articles.Repository;

namespace Query.Persistence.ArticleConfigs.Repository;

public class ArticleCategoryQueryRepository : IArticleCategoryQueryRepository
{
    private readonly string? _connectionString;

    public ArticleCategoryQueryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }

    private IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);

    public async Task<ArticleCategoryQr?> GetById(long id, CancellationToken ct)
    {
        const string sql = @"SELECT id, title, content, created_at 
                             FROM articleCategory 
                             WHERE id = @Id";

        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ArticleCategoryQr>(sql, new { Id = id });
    }

    public async Task<IEnumerable<ArticleCategoryQr>> GetAll()
    {
        const string sql = @"SELECT id, title, content, created_at 
                             FROM articleCategory 
                             ORDER BY created_at DESC";

        using var connection = CreateConnection();
        return await connection.QueryAsync<ArticleCategoryQr>(sql);
    }

    public async Task<(IEnumerable<ArticleCategoryQr> Items, int TotalCount)> SearchPagedAsync(string searchTerm, int pageNumber, int pageSize)
    {
        const string sqlData = @"SELECT id, title, content, created_at 
                                 FROM articleCategory 
                                 WHERE title ILIKE @Search OR content ILIKE @Search
                                 ORDER BY created_at DESC 
                                 OFFSET @Offset LIMIT @PageSize";

        const string sqlCount = @"SELECT COUNT(*) 
                                  FROM articleCategory 
                                  WHERE title ILIKE @Search OR content ILIKE @Search";

        using var connection = CreateConnection();

        var param = new
        {
            Search = $"%{searchTerm}%",
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize
        };

        var items = await connection.QueryAsync<ArticleCategoryQr>(sqlData, param);
        var totalCount = await connection.ExecuteScalarAsync<int>(sqlCount, param);

        return (items, totalCount);
    }
}