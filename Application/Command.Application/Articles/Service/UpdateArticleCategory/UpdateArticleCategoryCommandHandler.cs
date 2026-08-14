using Command.Application.Articles.Dto.UpdateArticleCategory;
using Command.Application.Articles.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Articles.Service.UpdateArticleCategory
{
    public class UpdateArticleCategoryCommandHandler : IRequestHandler<UpdateArticleCategoryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleCategoryCommandRepository _commandRepository;

        public UpdateArticleCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            IArticleCategoryCommandRepository commandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateArticleCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = _commandRepository.FindById(request.ArticleCategoryId);
            if (category == null)
            {
                return ResultDto<long>.Failure("Data Is Not Valid");
            }

            category.UpdateDate = DateTime.UtcNow;
            category.Description = request.Description;
            category.Title = request.Title;

            _commandRepository.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(category.Id, "Operation Succefully!!!");
        }
    }
}