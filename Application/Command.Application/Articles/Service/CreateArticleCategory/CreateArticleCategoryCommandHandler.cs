using Command.Application.Articles.Dto.CreateArticleCategory;
using Command.Application.Articles.Repository;
using MediatR;
using SampleForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Application.Articles.Service.CreateArticleCategory
{
    public class CreateArticleCategoryCommandHandler : IRequestHandler<CreateArticleCategoryCommand, ResultDto<long>>
    {
        private readonly IArticleCategoryCommandRepository _categoryCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateArticleCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            IArticleCategoryCommandRepository categoryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateArticleCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var existCategory = _categoryCommandRepository.FindByTitle(request.Title);
            if (existCategory is not null)
            {
                return ResultDto<long>.Failure("Article Title Is Duplicated");
            }

            var category = ArticleCategory.Create(request.Title, request.Description);

            _categoryCommandRepository.Create(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(category.Id, "Operation Successfully!!!");
        }
    }
}