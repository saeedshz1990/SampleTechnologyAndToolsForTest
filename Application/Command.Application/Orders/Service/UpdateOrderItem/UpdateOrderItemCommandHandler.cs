using Command.Application.Orders.Dto.UpdateOrderItem;
using Command.Application.Orders.Repository;
using Command.Application.Products.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Service.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderCommandRepository _commandRepository;
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IOrderItemCommandRepository _orderItemCommandRepository;

        public UpdateOrderItemCommandHandler(
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

        public async Task<ResultDto<long>> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var orderItem = _orderItemCommandRepository.FindById(request.OrderItemId);
            if (orderItem is null)
            {
                return ResultDto<long>.Failure("OrderItem Not Found!!!");
            }

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

            orderItem.UpdateDate = DateTime.UtcNow;
            orderItem.IsDeleted = false;
            orderItem.CountOfItem=request.CountOfItem;
            orderItem.DiscountOfAmount = request.DiscountOfAmount;

            _orderItemCommandRepository.Update(orderItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(orderItem.Id, "Operation Successfully!!!");
        }
    }
}
