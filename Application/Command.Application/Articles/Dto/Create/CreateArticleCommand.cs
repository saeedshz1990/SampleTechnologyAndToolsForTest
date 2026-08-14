using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Dto.Create
{
    public class CreateArticleCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long ArticleCategoryId { get; set; }
    }
}
