using Query.Application.Categories.QueryResult;

namespace Query.Application.Categories.Repository
{
    public interface ICategoryQueryRepository
    {
        Task<CategoryQr?> GetById(long id, CancellationToken ct);
        Task<IEnumerable<CategoryQr>> GetAll();

        Task<(IEnumerable<CategoryQr> Items, int TotalCount)> SearchPagedAsync
            (string searchTerm, int pageNumber, int pageSize);
    }
}