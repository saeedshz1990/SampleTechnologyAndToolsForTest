using Query.Application.Articles.QueryResult;

namespace Query.Application.Articles.Repository
{
    public interface IArticleQueryRepository
    {
        Task<ArticleQr?> GetById(long id, CancellationToken ct);
        Task<IEnumerable<ArticleQr>> GetAll();
        Task<(IEnumerable<ArticleQr> Items, int TotalCount)> SearchPagedAsync
            (string searchTerm, int pageNumber, int pageSize);
    }
}