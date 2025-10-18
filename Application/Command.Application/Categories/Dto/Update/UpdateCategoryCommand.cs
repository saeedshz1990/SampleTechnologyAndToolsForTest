using Command.Application.Categories.Dto.Create;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Categories.Dto.Update
{
    public class UpdateCategoryCommand :CreateCategoryCommand, IRequest<ResultDto<long>>
    {
        public long CategoryId { get; set; }
    }
}
