using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Dto.Create
{
    public class CreateOrderCommand : IRequest<ResultDto<long>>
    {
        public long OrderNumber { get; set; }
        public decimal FinalAmount { get; set; }
        public int NumberOfItems { get; set; }
        public int DiscountPercent { get; set; }
    }
}
