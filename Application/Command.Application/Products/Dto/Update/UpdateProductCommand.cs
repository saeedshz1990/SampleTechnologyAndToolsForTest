using Command.Application.Products.Dto.Create;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Products.Dto.Update
{
    public class UpdateProductCommand : CreateProductCommand, IRequest<ResultDto<long>>
    {
        public long ProductId { get; set; }
    }
}
