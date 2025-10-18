using Command.Application.Products.Dto.Delete;
using Command.Application.Products.Dto.Update;
using FluentValidation;

namespace Command.Application.Products.Service.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotNull().WithMessage("ProductId is required")
                .Must(IsValidId).WithMessage("ProductId Is Not Valid");

            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("CategoryId is required")
                .Must(IsValidId).WithMessage("CategoryId Is Not Valid");

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
