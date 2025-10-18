using Command.Application.Countries.Dto.Update;
using FluentValidation;

namespace Command.Application.Countries.Service.Update
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {
        public UpdateCountryCommandValidator()
        {
            RuleFor(x => x.CountryId)
              .NotEmpty().NotNull().WithMessage("CountryId is required")
              .Must(IsValidId).WithMessage("CountryId Id Is Not Valid");

            RuleFor(x => x.Title)
               .NotEmpty().NotNull().WithMessage("Title is required");

            RuleFor(x => x.CountryCode)
                .NotEmpty().NotNull().WithMessage("CountryCode is required");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
