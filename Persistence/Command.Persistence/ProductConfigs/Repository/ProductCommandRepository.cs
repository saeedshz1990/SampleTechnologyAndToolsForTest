using Command.Application.Products.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Products;

namespace Command.Persistence.ProductConfigs.Repository
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly SampleCommandContext _context;

        public ProductCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public async Task Create(Product command, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(command, cancellationToken).ConfigureAwait(true);
        }

        public void Update(Product command)
        {
            _context.Products.Update(command);
        }

        public void Delete(Product command)
        {
            _context.Products.Remove(command);
        }

        public Product? FindById(long productId)
        {
            return _context.Products.FirstOrDefault(_ => _.Id == productId);
        }
    }
}
