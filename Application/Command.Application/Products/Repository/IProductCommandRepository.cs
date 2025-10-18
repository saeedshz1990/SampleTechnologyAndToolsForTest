using SampleTechnologyForTest.Entities.Entity.Products;

namespace Command.Application.Products.Repository
{
    public interface IProductCommandRepository
    {
        Task Create(Product command, CancellationToken cancellationToken);
        void Update(Product command);
        void Delete(Product command);

        Product? FindById(long productId);
    }
}
