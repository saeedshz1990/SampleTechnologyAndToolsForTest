using Command.Application.Orders.Dto.Create;
using Command.Application.Orders.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Application.Orders.Service.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderCommandRepository _commandRepository;

        public CreateOrderCommandHandler(
            IUnitOfWork unitOfWork,
            IOrderCommandRepository commandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var order = Order.Create(request.OrderNumber, request.FinalAmount,
                                     request.NumberOfItems, request.DicountPercent);

            _commandRepository.Create(order, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(order.Id, "Operation Successfully!!!");
        }
    }
}
