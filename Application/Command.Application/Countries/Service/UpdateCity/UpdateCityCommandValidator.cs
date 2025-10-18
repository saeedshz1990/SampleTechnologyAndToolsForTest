using Command.Application.Countries.Dto.UpdateCity;
using FluentValidation;

namespace Command.Application.Countries.Service.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
        }
    }
}
