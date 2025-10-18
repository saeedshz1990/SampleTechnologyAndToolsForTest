using Command.Application.Categories.Dto.Delete;
using Command.Application.Categories.Repository;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Categories.Services.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryCommandRepository _categoryCommandRepository;

        public DeleteCategoryCommandHandler(
            IUnitOfWork unitOfWork, 
            ICategoryCommandRepository categoryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
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

            _categoryCommandRepository.Delete(category);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(category.Id, "Operation Successfully!!!");
        }
    }
}
