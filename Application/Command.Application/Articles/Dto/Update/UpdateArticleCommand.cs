using Command.Application.Articles.Dto.Create;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Articles.Dto.Update
{
    public class UpdateArticleCommand : IRequest<ResultDto<long>>
    {
        public long ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long ArticleCategoryId { get; set; }
    }
}
