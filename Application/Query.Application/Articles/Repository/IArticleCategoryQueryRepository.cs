using Query.Application.Articles.QueryResult;

namespace Query.Application.Articles.Repository
{
    public interface IArticleCategoryQueryRepository
    {
        Task<ArticleCategoryQr?> GetById(long id, CancellationToken ct);
        Task<IEnumerable<ArticleCategoryQr>> GetAll();
        Task<(IEnumerable<ArticleCategoryQr> Items, int TotalCount)> SearchPagedAsync
            (string searchTerm, int pageNumber, int pageSize);
    }
}
