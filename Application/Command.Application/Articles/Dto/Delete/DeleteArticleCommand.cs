using MediatR;
using SampleForTest.Common;

namespace Command.Application.Articles.Dto.Delete
{
    public class DeleteArticleCommand : IRequest<ResultDto<long>>
    {
        public long ArticleId { get; set; }
    }
}
