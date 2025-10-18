using Command.Application.Countries.Dto.DeleteProvince;
using FluentValidation;

namespace Command.Application.Countries.Service.DeleteProvince
{
    public class DeleteProvinceCommandValidator : AbstractValidator<DeleteProvinceCommand>
    {
        public DeleteProvinceCommandValidator()
        {
            RuleFor(x => x.ProvinceId)
                    .NotEmpty().NotNull().WithMessage("ProvinceId is required")
                    .Must(IsValidId).WithMessage("ProvinceId Not Valid");
        }
        public bool IsValidId(long id)
        {
            return id > 0;
        }
    }
}
