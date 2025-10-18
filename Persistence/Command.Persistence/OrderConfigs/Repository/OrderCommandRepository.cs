using Command.Application.Orders.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Persistence.OrderConfigs.Repository
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly SampleCommandContext _context;

        public OrderCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public void Create(Order command, CancellationToken cancellationToken)
        {
            _context.Orders.AddAsync(command, cancellationToken);
        }

        public void Delete(Order command)
        {
            _context.Orders.Remove(command);
        }

        public Order? FindById(long orderId)
        {
            return _context.Orders.FirstOrDefault(_ => _.Id == orderId);
        }

        public void Update(Order command)
        {
            _context.Orders.Update(command);
        }
    }
}
