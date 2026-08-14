using Command.Application.Orders.Dto.Update;
using Command.Application.Orders.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Service.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ResultDto<long>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderCommandRepository _commandRepository;

        public UpdateOrderCommandHandler(
            IUnitOfWork unitOfWork,
            IOrderCommandRepository commandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
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

            order.IsDeleted = false;
            order.UpdateDate = DateTime.UtcNow;
            order.FinalAmount = request.FinalAmount;
            order.NumberOfItems = request.NumberOfItems;
            order.DiscountPercent = request.DiscountPercent;

            _commandRepository.Update(order);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(order.Id, "Operation Successfully!!!");
        }
    }
}
