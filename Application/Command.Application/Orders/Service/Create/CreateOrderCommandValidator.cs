using Command.Application.Orders.Dto.Create;
using FluentValidation;

namespace Command.Application.Orders.Service.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.OrderNumber)
                .NotEmpty().NotNull().WithMessage("OrderNumber is required")
                .Must(IsValidId).WithMessage("OrderNumber Id Is Not Valid");

            RuleFor(x => x.NumberOfItems)
                .NotEmpty().NotNull().WithMessage("NumberOfItems is required")
                .Must(IsValidId).WithMessage("NumberOfItems Id Is Not Valid");

            RuleFor(x => x.DicountPercent)
                .NotEmpty().NotNull().WithMessage("DicountPercent is required");

            RuleFor(x => x.FinalAmount)
                .NotEmpty().NotNull().WithMessage("FinalAmount is required")
                .Must(IsValidId).WithMessage("FinalAmount Id Is Not Valid");

        }
        public bool IsValidId(long id)
        {
            return id > 0;
        }

        public bool IsValidId(int id)
        {
            return id > 0;
        }

        public bool IsValidId(double id)
        {
            return id > 0;
        }
    }
}
