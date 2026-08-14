using Command.Application.Orders.Dto.CreateOrderItem;
using Command.Application.Orders.Repository;
using Command.Application.Products.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Application.Orders.Service.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderCommandRepository _commandRepository;
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IOrderItemCommandRepository _orderItemCommandRepository;

        public CreateOrderItemCommandHandler(
            IUnitOfWork unitOfWork,
            IOrderCommandRepository commandRepository,
            IProductCommandRepository productCommandRepository,
            IOrderItemCommandRepository orderItemCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
            _productCommandRepository = productCommandRepository;
            _orderItemCommandRepository = orderItemCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var order = _commandRepository.FindById(request.OrderId);
            if (order is null)
            {
                return ResultDto<long>.Failure("Order Not Found!!!");
            }

            var product = _productCommandRepository.FindById(request.ProductId);

            if (product is null)
            {
                return ResultDto<long>.Failure("Product Not Found!!!");
            }

            var orderItem = OrderItem.Create(request.CountOfItem, request.DiscountOfAmount,
                                             request.ProductId, request.OrderId);


            _orderItemCommandRepository.Create(orderItem, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(orderItem.Id, "Operation Successfully!!!");
        }
    }
}
