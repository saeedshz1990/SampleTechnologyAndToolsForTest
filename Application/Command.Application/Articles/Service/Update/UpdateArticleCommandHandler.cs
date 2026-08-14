using Command.Application.Articles.Dto.Update;
using Command.Application.Articles.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Service.Update
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCommandRepository _articleCommandRepository;

        public UpdateArticleCommandHandler(
            IUnitOfWork unitOfWork, IArticleCommandRepository articleCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _articleCommandRepository = articleCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = _articleCommandRepository.FindById(request.ArticleId);
            if (article == null)
            {
                return ResultDto<long>.Failure("Article Not Found");
            }

            article.UpdateDate = DateTime.Now;
            article.Title = request.Title;
            article.Description = request.Description;
            article.Body = request.Body;
            article.Tag = request.Tag;
            article.IsDelete = false;

            _articleCommandRepository.Update(article);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultDto<long>.Success(article.Id, "Operation Successfully");
        }
    }
}