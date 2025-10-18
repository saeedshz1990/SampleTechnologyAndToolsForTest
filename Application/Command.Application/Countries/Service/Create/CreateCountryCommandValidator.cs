using Command.Application.Countries.Dto.Create;
using FluentValidation;

namespace Command.Application.Countries.Service.Create
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {

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
