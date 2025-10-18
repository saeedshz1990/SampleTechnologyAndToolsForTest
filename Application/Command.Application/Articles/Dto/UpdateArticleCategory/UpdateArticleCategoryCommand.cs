using MediatR;
using SampleForTest.Common;

namespace Command.Application.Articles.Dto.UpdateArticleCategory
{
    public class UpdateArticleCategoryCommand : IRequest<ResultDto<long>>
    {
        public long ArticleCategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
