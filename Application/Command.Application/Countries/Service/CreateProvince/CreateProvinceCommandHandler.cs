using Command.Application.Countries.Dto.CreateProvince;
using Command.Application.Countries.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Service.CreateProvince
{
    public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProvinceCommandRepository _commandRepository;
        private readonly ICountryCommandRepository _countryCommandRepository;

        public CreateProvinceCommandHandler(
            IUnitOfWork unitOfWork,
            IProvinceCommandRepository commandRepository,
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
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

            var province = Province.Create(request.Title, request.CountryId);

            await _commandRepository.Create(province, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(province.Id, "Operation Successfully!!!");
        }
    }
}
