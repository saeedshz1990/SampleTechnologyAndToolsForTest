using MediatR;
using SampleForTest.Common;

namespace Command.Application.Orders.Dto.CreateOrderItem
{
    public class CreateOrderItemCommand : IRequest<ResultDto<long>>
    {
        public int CountOfItem { get; set; }
        public int DiscountOfAmount { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
    }
}
