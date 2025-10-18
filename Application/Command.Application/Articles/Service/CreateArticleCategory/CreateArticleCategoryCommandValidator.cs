using Command.Application.Articles.Dto.CreateArticleCategory;
using FluentValidation;

namespace Command.Application.Articles.Service.CreateArticleCategory
{
    public class CreateArticleCategoryCommandValidator : AbstractValidator<CreateArticleCategoryCommand>
    {
        public CreateArticleCategoryCommandValidator()
        {

            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");

        }
    }
}
