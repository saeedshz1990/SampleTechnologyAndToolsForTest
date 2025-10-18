using Command.Application.Countries.Dto.UpdateProvince;
using FluentValidation;

namespace Command.Application.Countries.Service.UpdateProvince
{
    public class UpdateProvinceCommandValidator : AbstractValidator<UpdateProvinceCommand>
    {
        public UpdateProvinceCommandValidator()
        {
            RuleFor(x => x.CountryId)
                .NotEmpty().NotNull().WithMessage("CountryId is required")
                .Must(IsValidId).WithMessage("CountryId Not Valid");

            RuleFor(x => x.ProvinceId)
                .NotEmpty().NotNull().WithMessage("ProvinceId is required")
                .Must(IsValidId).WithMessage("ProvinceId Not Valid");

            RuleFor(x => x.Title)
                .NotEmpty().NotNull().WithMessage("Title is required");
        }

        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
