using Command.Application.Products.Dto.Create;
using Command.Application.Products.Dto.Update;
using Command.Application.Products.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Products;

namespace Command.Application.Products.Service.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResultDto<long>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCommandRepository _productCommandRepository;

        public UpdateProductCommandHandler(
            IUnitOfWork unitOfWork, 
            IProductCommandRepository productCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _productCommandRepository = productCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };
            var product = _productCommandRepository.FindById(request.ProductId);
            if (product is null)
            {
                ResultDto<long>.Failure("Product Not Found!!!");
            }

            product!.UpdateDate= DateTime.UtcNow;
            product.IsDeleted= false;
            product.Title=request.Title;
            product.Description=request.Description;
            product.CategoryId=request.CategoryId;

            _productCommandRepository.Update(product);


            await _unitOfWork.SaveChangesAndCommitAsync(cancellationToken);

            return ResultDto<long>.Success(product.Id, "Operation Successfully!!!");
        }
    }
}
