using Command.Application.Articles.Dto.DeleteArticleCategory;
using FluentValidation;

namespace Command.Application.Articles.Service.DeleteArticleCategory
{
    public class DeleteArticleCategoryCommandValidator : AbstractValidator<DeleteArticleCategoryCommand>
    {
        public DeleteArticleCategoryCommandValidator()
        {
            RuleFor(x => x.ArticleCategoryId).NotEmpty().NotNull().WithMessage("ArticleCategoryId is required")
              .Must(IsValidId).WithMessage("ArticleCategoryId Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
