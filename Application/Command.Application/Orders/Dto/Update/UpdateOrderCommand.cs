using Command.Application.Orders.Dto.Create;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Dto.Update
{
    public class UpdateOrderCommand :CreateOrderCommand, IRequest<ResultDto<long>>
    {
        public long OrderId { get; set; }
    }
}
