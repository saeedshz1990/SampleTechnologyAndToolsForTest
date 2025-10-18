using Command.Application.Countries.Dto.CreateCity;
using Command.Application.Countries.Dto.DeleteCity;
using Command.Application.Countries.Repository;
using MediatR;
using SampleForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Service.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityCommandRepository _cityCommandRepository;
        private readonly IProvinceCommandRepository _commandRepository;
        private readonly ICountryCommandRepository _countryCommandRepository;
        public DeleteCityCommandHandler(
            IUnitOfWork unitOfWork, 
            ICityCommandRepository cityCommandRepository, 
            IProvinceCommandRepository commandRepository, 
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _cityCommandRepository = cityCommandRepository;
            _commandRepository = commandRepository;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            Country? country = _countryCommandRepository.FindById(request.CountryId);
            if (country is null)
            {
                ResultDto<long>.Failure("Country NotFound!!!");
            }

            Province? province = _commandRepository.FindById(request.ProvinceId);

            if (province is null)
            {
                ResultDto<long>.Failure("Province NotFound!!!");
            }

            City? city = _cityCommandRepository.FindById(request.CityId);

            if (city is null)
            {
                ResultDto<long>.Failure("City NotFound!!!");
            }

            _cityCommandRepository.Delete(city!);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(request.CityId, "Operation Successfully!!!");
        }
    }
}
