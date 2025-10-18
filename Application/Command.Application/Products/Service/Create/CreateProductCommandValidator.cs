using Command.Application.Products.Dto.Create;
using FluentValidation;

namespace Command.Application.Products.Service.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.CategoryId)
               .NotEmpty().NotNull().WithMessage("CategoryId is required")
               .Must(IsValidId).WithMessage("CategoryId Id Is Not Valid");

            RuleFor(x => x.Title)
                .NotEmpty().NotNull().WithMessage("Title is required");

            RuleFor(x => x.Description)
                .NotEmpty().NotNull().WithMessage("Description is required");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
