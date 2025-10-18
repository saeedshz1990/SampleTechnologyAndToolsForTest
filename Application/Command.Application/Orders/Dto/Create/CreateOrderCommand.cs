using MediatR;
using SampleForTest.Common;

namespace Command.Application.Orders.Dto.Create
{
    public class CreateOrderCommand : IRequest<ResultDto<long>>
    {
        public long OrderNumber { get; set; }
        public double FinalAmount { get; set; }
        public int NumberOfItems { get; set; }
        public int DicountPercent { get; set; }
    }
}
