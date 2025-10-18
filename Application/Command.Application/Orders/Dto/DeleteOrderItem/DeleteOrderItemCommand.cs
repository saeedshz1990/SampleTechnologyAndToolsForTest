using MediatR;
using SampleForTest.Common;

namespace Command.Application.Orders.Dto.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest<ResultDto<long>>
    {
        public long OrderItemId { get; set; }
    }
}
