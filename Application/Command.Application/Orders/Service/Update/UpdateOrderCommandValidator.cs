using Command.Application.Orders.Dto.Create;
using Command.Application.Orders.Dto.Update;
using FluentValidation;

namespace Command.Application.Orders.Service.Update
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.OrderId)
               .NotEmpty().NotNull().WithMessage("OrderId is required")
               .Must(IsValidId).WithMessage("OrderId Id Is Not Valid");

            RuleFor(x => x.OrderNumber)
                .NotEmpty().NotNull().WithMessage("OrderNumber is required")
                .Must(IsValidId).WithMessage("OrderNumber Id Is Not Valid");

            RuleFor(x => x.NumberOfItems)
                .NotEmpty().NotNull().WithMessage("NumberOfItems is required")
                .Must(IsValidId).WithMessage("NumberOfItems Id Is Not Valid");

            RuleFor(x => x.DiscountPercent)
                .NotEmpty().NotNull().WithMessage("DiscountPercent is required");

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

        public bool IsValidId(decimal id)
        {
            return id > 0;
        }
    }
}
