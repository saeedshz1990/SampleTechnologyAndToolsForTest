using Microsoft.EntityFrameworkCore;
using Query.Application.Products.QueryResult;
using Query.Application.Products.Repository;
using Query.Persistence.Common;

namespace Query.Persistence.ProductConfigs.Repository
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly SampleQueryContext _context;

        public ProductQueryRepository(SampleQueryContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductQr>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<ProductQr?> GetByIdAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
