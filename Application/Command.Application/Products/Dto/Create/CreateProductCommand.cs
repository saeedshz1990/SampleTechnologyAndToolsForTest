using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Products.Dto.Create
{
    public class CreateProductCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long CategoryId { get; set; }
    }
}
