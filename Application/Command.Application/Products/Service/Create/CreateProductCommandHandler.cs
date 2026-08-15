using Command.Application.Products.Dto.Create;
using Command.Application.Products.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Outbox;
using SampleTechnologyForTest.Entities.Entity.Products;
using SampleTechnologyForTest.Entities.Events.Products;
using System.Text.Json;

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

            var productCreatedEvent = new ProductCreatedEvent(
                                            product.Id,
                                            product.Title,
                                            product.Description,
                                            product.CategoryId);

            var outboxMessage = new OutboxMessage
            {
                Type = nameof(ProductCreatedEvent),
                Payload = JsonSerializer.Serialize(productCreatedEvent)
            };

            await _productCommandRepository.Create(product, cancellationToken);

            await _unitOfWork.SaveChangesAndCommitAsync(cancellationToken);
            await _unitOfWork.AddOutboxMessageAsync(outboxMessage,cancellationToken);

            return ResultDto<long>.Success(product.Id, "Operation Successfully!!!");
        }
    }
}
