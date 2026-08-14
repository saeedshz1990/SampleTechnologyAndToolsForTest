using MediatR;
using Query.Application.Articles.Dto.GetById;
using Query.Application.Articles.QueryResult;
using Query.Application.Articles.Repository;
using SampleTechnologyForTest.Common;

namespace Query.Application.Articles.Service.GetById
{
    public class GetByIdArticleQueryHandler : IRequestHandler<GetArticleByIdQuery, ResultDto<ArticleQr>>
    {
        private readonly IArticleQueryRepository _articleQueryRepository;

        public GetByIdArticleQueryHandler(IArticleQueryRepository articleQueryRepository)
        {
            _articleQueryRepository = articleQueryRepository;
        }

        public async Task<ResultDto<ArticleQr>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleQueryRepository.GetById(request.ArticleId, cancellationToken);
            if (article == null)
            {
                return ResultDto<ArticleQr>.Failure("article Not Found");
            }

            return ResultDto<ArticleQr>.Success(article, "Operation Successfully!!!");
        }
    }
}