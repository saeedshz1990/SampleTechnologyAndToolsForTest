using Command.Application.Countries.Dto.CreateCity;
using FluentValidation;

namespace Command.Application.Countries.Service.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(x => x.Title)
                    .NotEmpty().NotNull().WithMessage("Title is required");

            RuleFor(x => x.CountryId)
                     .NotEmpty().NotNull().WithMessage("CountryId is required")
                     .Must(IsValidId).WithMessage("CountryId Not Valid");

            RuleFor(x => x.ProvinceId)
                    .NotEmpty().NotNull().WithMessage("CountryId is required")
                    .Must(IsValidId).WithMessage("CountryId Not Valid");

        }
        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
