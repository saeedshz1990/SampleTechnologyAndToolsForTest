using Command.Application.Articles.Dto.Delete;
using Command.Application.Articles.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Service.Delete
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, ResultDto<long>>
    {
        private readonly IArticleCommandRepository _articleCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteArticleCommandHandler(
            IArticleCommandRepository articleCommandRepository,
            IUnitOfWork unitOfWork)
        {
            _articleCommandRepository = articleCommandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDto<long>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = _articleCommandRepository.FindById(request.ArticleId);
            if (article == null)
            {
                ResultDto<long>.Failure("Article Not Found");
            }

            _articleCommandRepository.Delete(article);
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);


            return ResultDto<long>.Success(article.Id);
        }
    }
}
