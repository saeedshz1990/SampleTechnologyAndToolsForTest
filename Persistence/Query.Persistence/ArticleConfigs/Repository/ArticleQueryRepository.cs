using Dapper;                // ← متدهای افزونه‌ی Dapper
using Microsoft.Extensions.Configuration;
using Npgsql;
using Query.Application.Articles.QueryResult;
using Query.Application.Articles.Repository;
using System.Data;

namespace Query.Persistence.ArticleConfigs.Repository
{
    public class ArticleQueryRepository : IArticleQueryRepository
    {
        private readonly string? _connectionString;

        public ArticleQueryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnection");
        }
        
        private IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
        
        public async Task<IEnumerable<ArticleQr>> GetAll()
        {
            const string sql = @"SELECT id, title, content, created_at 
                             FROM articles 
                             ORDER BY created_at DESC";

            using var connection = CreateConnection();
            return await connection.QueryAsync<ArticleQr>(sql);
        }

        public async Task<(IEnumerable<ArticleQr> Items, int TotalCount)> SearchPagedAsync(string searchTerm, int pageNumber, int pageSize)
        {
            const string sqlData = @"SELECT id, title, content, created_at 
                                 FROM articles 
                                 WHERE title ILIKE @Search OR content ILIKE @Search
                                 ORDER BY created_at DESC 
                                 OFFSET @Offset LIMIT @PageSize";

            const string sqlCount = @"SELECT COUNT(*) 
                                  FROM articles 
                                  WHERE title ILIKE @Search OR content ILIKE @Search";

            using var connection = CreateConnection();

            var param = new
            {
                Search = $"%{searchTerm}%",
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            };

            var items = await connection.QueryAsync<ArticleQr>(sqlData, param);
            var totalCount = await connection.ExecuteScalarAsync<int>(sqlCount, param);

            return (items, totalCount);
        }

        public async Task<ArticleQr?> GetById(long id, CancellationToken ct)
        {
            const string sql = @"SELECT id, title, content, created_at 
                             FROM articles 
                             WHERE id = @Id";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ArticleQr>(sql, new { Id = id });
        }
    }
}
