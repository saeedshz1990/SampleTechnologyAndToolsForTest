using MediatR;
using Query.Application.Articles.QueryResult;
using SampleForTest.Common;

namespace Query.Application.Articles.Dto.GetAll
{
    public class GetAllArticleCommand :IRequest<ResultDto<IEnumerable<ArticleQr>>>
    {
    }
}
