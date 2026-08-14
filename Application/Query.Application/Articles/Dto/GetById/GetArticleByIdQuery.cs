using MediatR;
using Query.Application.Articles.QueryResult;
using SampleTechnologyForTest.Common;

namespace Query.Application.Articles.Dto.GetById
{
    public class GetArticleByIdQuery :IRequest<ResultDto<ArticleQr>>
    {
        public long ArticleId { get; set; }
    }
}
