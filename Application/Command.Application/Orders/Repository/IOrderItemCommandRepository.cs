using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Application.Orders.Repository
{
    public interface IOrderItemCommandRepository
    {
        void Create(OrderItem command, CancellationToken cancellationToken);
        void Update(OrderItem command);
        void Delete(OrderItem command);
        OrderItem? FindById(long orderItemId);
    }
}
