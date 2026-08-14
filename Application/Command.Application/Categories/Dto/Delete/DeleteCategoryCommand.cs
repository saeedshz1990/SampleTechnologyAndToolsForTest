using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Categories.Dto.Delete
{
    public class DeleteCategoryCommand : IRequest<ResultDto<long>>
    {
        public long CategoryId { get; set; }
    }
}
