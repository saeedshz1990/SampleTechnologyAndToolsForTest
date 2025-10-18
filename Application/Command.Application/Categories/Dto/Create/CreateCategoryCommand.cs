using MediatR;
using SampleForTest.Common;

namespace Command.Application.Categories.Dto.Create
{
    public class CreateCategoryCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
