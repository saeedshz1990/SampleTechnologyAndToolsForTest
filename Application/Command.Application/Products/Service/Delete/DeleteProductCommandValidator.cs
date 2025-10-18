using Command.Application.Products.Dto.Delete;
using FluentValidation;

namespace Command.Application.Products.Service.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {

            RuleFor(x => x.ProductId)
               .NotEmpty().NotNull().WithMessage("CategoryId is required")
               .Must(IsValidId).WithMessage("CategoryId Id Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
