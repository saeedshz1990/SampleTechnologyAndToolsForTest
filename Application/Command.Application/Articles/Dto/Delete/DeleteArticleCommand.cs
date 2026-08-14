using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Dto.Delete
{
    public class DeleteArticleCommand : IRequest<ResultDto<long>>
    {
        public long ArticleId { get; set; }
    }
}
