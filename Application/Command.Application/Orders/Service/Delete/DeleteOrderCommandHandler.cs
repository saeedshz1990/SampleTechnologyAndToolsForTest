using Command.Application.Orders.Dto.Create;
using Command.Application.Orders.Dto.Delete;
using Command.Application.Orders.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Orders.Service.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderCommandRepository _commandRepository;

        public DeleteOrderCommandHandler(
            IUnitOfWork unitOfWork, 
            IOrderCommandRepository commandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
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


            _commandRepository.Delete(order);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(request.OrderId, "Operation Successfully!!!");
        }
    }
}
