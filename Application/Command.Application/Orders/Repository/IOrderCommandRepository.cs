using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Application.Orders.Repository
{
    public interface IOrderCommandRepository
    {
        void Create(Order command, CancellationToken cancellationToken);
        void Update(Order command);
        void Delete(Order command);

        Order? FindById(long orderId);
    }
}
