using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Dto.CreateArticleCategory
{
    public class CreateArticleCategoryCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
