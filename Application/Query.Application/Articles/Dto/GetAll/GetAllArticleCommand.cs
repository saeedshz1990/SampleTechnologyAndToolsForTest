using MediatR;
using Query.Application.Articles.QueryResult;
using SampleTechnologyForTest.Common;

namespace Query.Application.Articles.Dto.GetAll
{
    public class GetAllArticleCommand :IRequest<ResultDto<IEnumerable<ArticleQr>>>
    {

    }
}
