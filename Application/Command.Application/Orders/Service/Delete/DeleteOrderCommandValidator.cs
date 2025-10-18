using Command.Application.Orders.Dto.Create;
using Command.Application.Orders.Dto.Delete;
using FluentValidation;

namespace Command.Application.Orders.Service.Delete
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.OrderId)
              .NotEmpty().NotNull().WithMessage("OrderId is required")
              .Must(IsValidId).WithMessage("OrderId Id Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
