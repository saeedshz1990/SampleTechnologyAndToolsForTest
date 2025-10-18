using Command.Application.Orders.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Persistence.OrderConfigs.Repository
{
    public class OrderItemCommandRepository : IOrderItemCommandRepository
    {
        private readonly SampleCommandContext _context;

        public OrderItemCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public void Create(OrderItem command, CancellationToken cancellationToken)
        {
            _context.OrderItems.AddAsync(command, cancellationToken);
        }

        public void Delete(OrderItem command)
        {
            _context.OrderItems.Remove(command);
        }

        public OrderItem? FindById(long orderItemId)
        {
            return _context.OrderItems.FirstOrDefault(_=>_.Id== orderItemId);
        }

        public void Update(OrderItem command)
        {
            _context.OrderItems.Update(command);
        }
    }
}
