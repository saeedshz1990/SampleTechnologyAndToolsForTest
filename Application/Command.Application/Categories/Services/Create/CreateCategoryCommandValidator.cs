using Command.Application.Categories.Dto.Create;
using FluentValidation;

namespace Command.Application.Categories.Services.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
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
