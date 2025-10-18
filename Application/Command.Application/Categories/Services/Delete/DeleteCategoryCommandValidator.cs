using Command.Application.Categories.Dto.Delete;
using FluentValidation;

namespace Command.Application.Categories.Services.Delete
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryId)
               .NotEmpty().NotNull().WithMessage("CategoryId is required")
               .Must(IsValidId).WithMessage("CategoryId Id Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
