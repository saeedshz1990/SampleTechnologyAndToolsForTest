using Command.Application.Products.Dto.Delete;
using Command.Application.Products.Repository;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Products.Service.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCommandRepository _productCommandRepository;

        public DeleteProductCommandHandler(
            IUnitOfWork unitOfWork,
            IProductCommandRepository productCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _productCommandRepository = productCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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

            _productCommandRepository.Delete(product);

            await _unitOfWork.SaveChangesAndCommitAsync(cancellationToken);

            return ResultDto<long>.Success(request.ProductId, "Operation Successfully!!!");
        }
    }
}
