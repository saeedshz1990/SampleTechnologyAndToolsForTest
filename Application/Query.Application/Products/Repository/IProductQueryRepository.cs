using Query.Application.Products.QueryResult;

namespace Query.Application.Products.Repository
{
    public interface IProductQueryRepository
    {
        Task<IReadOnlyList<ProductQr>> GetAllAsync(
        CancellationToken cancellationToken = default);

        Task<ProductQr?> GetByIdAsync(
            long id,
            CancellationToken cancellationToken = default);
    }
}
