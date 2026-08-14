using Command.Application.Products.Dto.Create;
using Command.Application.Products.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Products;

namespace Command.Application.Products.Service.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCommandRepository _productCommandRepository;

        public CreateProductCommandHandler(
            IUnitOfWork unitOfWork,
            IProductCommandRepository productCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _productCommandRepository = productCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var product = Product.Create(request.Title, request.Description, request.CategoryId);

            await _productCommandRepository.Create(product, cancellationToken);

            await _unitOfWork.SaveChangesAndCommitAsync(cancellationToken);

            return ResultDto<long>.Success(product.Id, "Operation Successfully!!!");
        }
    }
}
