using Command.Application.Countries.Dto.Create;
using Command.Application.Countries.Dto.CreateProvince;
using FluentValidation;

namespace Command.Application.Countries.Service.CreateProvince
{
    public class CreateProvinceCommandValidator : AbstractValidator<CreateProvinceCommand>
    {
        public CreateProvinceCommandValidator()
        {
            RuleFor(x => x.Title)
                     .NotEmpty().NotNull().WithMessage("Title is required");

            RuleFor(x => x.CountryId)
                     .NotEmpty().NotNull().WithMessage("CountryId is required")
                     .Must(IsValidId).WithMessage("CountryId Not Valid");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
