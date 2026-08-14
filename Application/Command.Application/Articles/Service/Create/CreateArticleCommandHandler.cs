using Command.Application.Articles.Dto.Create;
using Command.Application.Articles.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Application.Articles.Service.Create
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ResultDto<long>>
    {
        private readonly IArticleCommandRepository _articleCommandRepository;
        private readonly IArticleCategoryCommandRepository _categoryCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateArticleCommandHandler(
            IArticleCommandRepository articleCommandRepository,
            IUnitOfWork unitOfWork,
            IArticleCategoryCommandRepository categoryCommandRepository)
        {
            _articleCommandRepository = articleCommandRepository;
            _unitOfWork = unitOfWork;
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var category = _categoryCommandRepository.FindById(request.ArticleCategoryId);
            if (category is null)
            {
                return ResultDto<long>.Failure("Category NotFound");
            }

            var article = _articleCommandRepository.FindByTitle(request.Title);
            if (article != null)
            {
                return ResultDto<long>.Failure("article Is Exists");
            }

            var newArticle = Article.Create(request.Title, request.Body, request.Tag, request.Description,
                request.ArticleCategoryId);

            _articleCommandRepository.Create(newArticle, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(newArticle.Id, "Operation Successfully!!!");
        }
    }
}