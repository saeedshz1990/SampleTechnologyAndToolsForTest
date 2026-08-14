using Command.Application.Articles.Dto.DeleteArticleCategory;
using Command.Application.Articles.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Service.DeleteArticleCategory
{
    public class DeleteArticleCategoryCommandHandler :
        IRequestHandler<DeleteArticleCategoryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryCommandRepository _commandRepository;

        public DeleteArticleCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            IArticleCategoryCommandRepository commandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            var articleCategory = _commandRepository.FindById(request.ArticleCategoryId);
            if (articleCategory == null)
            {
                return ResultDto<long>.Failure("articleCategory Not Found");
            }

            _commandRepository.Delete(articleCategory);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultDto<long>.Success(articleCategory.Id, "Operation SUccessfully");
        }
    }
}
