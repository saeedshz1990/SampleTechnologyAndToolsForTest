using Command.Application.Countries.Dto.DeleteProvince;
using Command.Application.Countries.Repository;
using MediatR;
using SampleTechnologyForTest.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Service.DeleteProvince
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, ResultDto<long>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProvinceCommandRepository _commandRepository;
        private readonly ICountryCommandRepository _countryCommandRepository;

        public DeleteProvinceCommandHandler(
            IUnitOfWork unitOfWork,
            IProvinceCommandRepository commandRepository,
            ICountryCommandRepository countryCommandRepository)
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
            _countryCommandRepository = countryCommandRepository;
        }

        public async Task<ResultDto<long>> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {
            ResultDto<long> result = new ResultDto<long>
            {
                IsSuccess = true,
                Message = "",
                Data = 1,
                Errors = []
            };

            Province? province = _commandRepository.FindById(request.ProvinceId);

            if (province is null)
            {
                ResultDto<long>.Failure("Province NotFound!!!");
            }

            _commandRepository.Delete(province!);

            await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(true);

            return ResultDto<long>.Success(request.ProvinceId, "Operation Successfully!!!");
        }
    }
}
