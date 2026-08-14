using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Dto.DeleteArticleCategory
{
    public class DeleteArticleCategoryCommand : IRequest<ResultDto<long>>
    {
        public long ArticleCategoryId { get; set; }
    }
}
