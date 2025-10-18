using Command.Application.Orders.Dto.CreateOrderItem;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Orders.Dto.UpdateOrderItem
{
    public class UpdateOrderItemCommand :CreateOrderItemCommand, IRequest<ResultDto<long>>
    {
        public long OrderItemId { get; set; }
    }
}
