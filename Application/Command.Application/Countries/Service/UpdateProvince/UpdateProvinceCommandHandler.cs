using Command.Application.Countries.Dto.UpdateProvince;
using Command.Application.Countries.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Service.UpdateProvince
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, ResultDto<long>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProvinceCommandRepository _commandRepository;
        private readonly ICountryCommandRepository _countryCommandRepository;

        public UpdateProvinceCommandHandler(
            IUnitOfWork unitOfWork,
            IProvinceCommandRepository commandRepository,
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
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

            province!.UpdateDate = DateTime.Now;
            province.IsDelete = false;
            province.Title = request.Title;
            province.CountryId = request.CountryId;

            _commandRepository.Update(province);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(province.Id, "Operation Successfully!!!");
        }
    }
}
