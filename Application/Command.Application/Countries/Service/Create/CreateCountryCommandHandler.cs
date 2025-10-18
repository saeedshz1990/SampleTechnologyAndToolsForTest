using Command.Application.Countries.Dto.Create;
using Command.Application.Countries.Repository;
using MediatR;
using SampleForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Service.Create
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryCommandRepository _countryCommandRepository;

        public CreateCountryCommandHandler(
            IUnitOfWork unitOfWork,
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var country = Country.Create(request.Title, request.CountryCode);

            await _countryCommandRepository.Create(country, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(country.Id, "Operation Successfully!!!");
        }
    }
}
