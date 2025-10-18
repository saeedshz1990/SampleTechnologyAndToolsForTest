using Command.Application.Categories.Dto.Update;
using FluentValidation;

namespace Command.Application.Categories.Services.Update
{
    public class UpdateCategoryCommandValidator :AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().NotNull().WithMessage("Title is required");
            RuleFor(x => x.Description)
                .NotEmpty().NotNull().WithMessage("Description is required");
            RuleFor(x => x.CategoryId)
                .NotEmpty().NotNull().WithMessage("ArticleCategoryId is required")
                .Must(IsValidId).WithMessage("ArticleCategory Id Is Not Valid");
            
        }
        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
