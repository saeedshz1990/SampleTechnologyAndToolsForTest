using Command.Application.Countries.Dto.DeleteCity;
using FluentValidation;

namespace Command.Application.Countries.Service.DeleteCity
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator()
        {
        }
    }
}
