using Command.Application.Articles.Dto.Delete;
using FluentValidation;

namespace Command.Application.Articles.Service.Delete
{
    public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
    {
        public DeleteArticleCommandValidator()
        {

            RuleFor(x => x.ArticleId).NotEmpty().NotNull().WithMessage("ArticleId is required")
                .Must(IsValidId).WithMessage("ArticleId Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
