using Command.Application.Countries.Dto.Delete;
using FluentValidation;

namespace Command.Application.Countries.Service.Delete
{
    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.CountryId)
               .NotEmpty().NotNull().WithMessage("CountryId is required")
               .Must(IsValidId).WithMessage("CountryId Id Is Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
