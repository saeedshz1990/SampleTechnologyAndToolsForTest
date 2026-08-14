using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Dto.Delete
{
    public class DeleteOrderCommand : IRequest<ResultDto<long>>
    {
        public long OrderId { get; set; }
    }
}
