using Command.Application.Countries.Dto.Delete;
using Command.Application.Countries.Repository;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Countries.Service.Delete
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryCommandRepository _countryCommandRepository;

        public DeleteCountryCommandHandler(
            IUnitOfWork unitOfWork,
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            var country = _countryCommandRepository.FindById(request.CountryId);

            if (country is null)
            {
                ResultDto<long>.Failure("Country NotFound!!!");
            }

            _countryCommandRepository.Delete(country!);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(request.CountryId, "Operation Successfully!!!");
        }
    }
}
