using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Dto.DeleteOrderItem
{
    public class DeleteOrderItemCommand : IRequest<ResultDto<long>>
    {
        public long OrderItemId { get; set; }
    }
}
