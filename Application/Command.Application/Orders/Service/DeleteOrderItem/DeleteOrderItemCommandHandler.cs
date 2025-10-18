using Command.Application.Orders.Dto.DeleteOrderItem;
using Command.Application.Orders.Repository;
using Command.Application.Products.Repository;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Orders.Service.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderCommandRepository _commandRepository;
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IOrderItemCommandRepository _orderItemCommandRepository;

        public DeleteOrderItemCommandHandler(
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

        public async Task<ResultDto<long>> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
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

            _orderItemCommandRepository.Delete(orderItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(request.OrderItemId, "Operation Successfully!!!");
        }
    }
}
