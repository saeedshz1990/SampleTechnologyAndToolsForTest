using Command.Application.Countries.Dto.Update;
using Command.Application.Countries.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Service.Update
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryCommandRepository _countryCommandRepository;

        public UpdateCountryCommandHandler(
            IUnitOfWork unitOfWork,
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
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

            country!.UpdateDate= DateTime.Now;
            country.IsDelete = false;
            country.Title =request.Title;
            country.CountryCode = request.CountryCode;

            _countryCommandRepository.Update(country);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(request.CountryId, "Operation Successfully!!!");
        }
    }
}
