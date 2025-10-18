using Command.Application.Articles.Dto.Update;
using FluentValidation;

namespace Command.Application.Articles.Service.Update
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required");
            RuleFor(x => x.Body).NotEmpty().NotNull().WithMessage("Body is required");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description is required");
            RuleFor(x => x.Tag).NotEmpty().NotNull().WithMessage("Tag is required");
            RuleFor(x => x.ArticleCategoryId).NotEmpty().NotNull().WithMessage("ArticleCategoryId is required")
                .Must(IsValidId).WithMessage("ArticleCategoryId Id Is Not Valid");
        }
        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
