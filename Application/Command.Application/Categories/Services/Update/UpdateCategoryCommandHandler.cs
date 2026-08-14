using Command.Application.Categories.Dto.Update;
using Command.Application.Categories.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Categories.Services.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public UpdateCategoryCommandHandler(
            IUnitOfWork unitOfWork,
            ICategoryCommandRepository categoryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var category = _categoryCommandRepository.FindById(request.CategoryId);
            if (category is null)
            {
                return ResultDto<long>.Failure("Category NotFound");
            }

            category.Description = request.Description;
            category.Title = request.Title;
            category.UpdateDate = DateTime.UtcNow;
            category.IsDeleted = false;

            _categoryCommandRepository.Update(category);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(category.Id, "Operation Successfully!!!");
        }
    }
}