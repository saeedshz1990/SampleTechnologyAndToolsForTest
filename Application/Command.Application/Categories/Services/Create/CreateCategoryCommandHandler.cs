using Command.Application.Categories.Dto.Create;
using Command.Application.Categories.Repository;
using MediatR;
using SampleForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Categories;

namespace Command.Application.Categories.Services.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryCommandRepository  _categoryCommandRepository;
        
        public CreateCategoryCommandHandler(
            IUnitOfWork unitOfWork, 
            ICategoryCommandRepository categoryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryCommandRepository = categoryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var category = _categoryCommandRepository.FindByTitle(request.Title);
            if (category != null)
            {
                return ResultDto<long>.Failure("Category Exists");
            }
            
            var newCategory=Category.Create(request.Title, request.Description);
            _categoryCommandRepository.Create(newCategory,cancellationToken);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(newCategory.Id, "Operation Successfully!!!");
        }
    }
}
