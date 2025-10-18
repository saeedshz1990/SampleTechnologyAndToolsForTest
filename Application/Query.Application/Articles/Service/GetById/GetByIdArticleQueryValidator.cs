using FluentValidation;
using Query.Application.Articles.Dto.GetById;
using Query.Application.Categories.Dto.GetById;

namespace Query.Application.Articles.Service.GetById
{
    public class GetByIdArticleQueryValidator : AbstractValidator<GetArticleByIdQuery>
    {
        public GetByIdArticleQueryValidator()
        {
            RuleFor(x => x.ArticleId).NotEmpty().NotNull().WithMessage("ArticleId is required")
               .Must(IsValidId).WithMessage("Article Id Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
