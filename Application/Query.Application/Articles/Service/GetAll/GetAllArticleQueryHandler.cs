using MediatR;
using Query.Application.Articles.Dto.GetAll;
using Query.Application.Articles.QueryResult;
using Query.Application.Articles.Repository;
using SampleTechnologyForTest.Common;


namespace Query.Application.Articles.Service.GetAll
{
    public class GetAllArticleQueryHandler : IRequestHandler<GetAllArticleCommand, ResultDto<IEnumerable<ArticleQr>>>
    {
        private readonly IArticleQueryRepository _articleQueryRepository;
        public GetAllArticleQueryHandler(IArticleQueryRepository articleQueryRepository)
        {
            _articleQueryRepository = articleQueryRepository;
        }

        public async Task<ResultDto<IEnumerable<ArticleQr>>> Handle(GetAllArticleCommand request, CancellationToken cancellationToken)
        {
            var query = await _articleQueryRepository.GetAll();
            // return ResultDto<List<ArticleQr>>.Success(query, "Get All Article Succefully!!");
            return null;
        }
    }
}
