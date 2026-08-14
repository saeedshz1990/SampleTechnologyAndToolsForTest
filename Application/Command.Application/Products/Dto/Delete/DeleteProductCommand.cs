using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Products.Dto.Delete
{
    public class DeleteProductCommand : IRequest<ResultDto<long>>
    {
        public long ProductId { get; set; }
    }
}
