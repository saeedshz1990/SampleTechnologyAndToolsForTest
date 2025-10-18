using Command.Application.Countries.Dto.UpdateCity;
using MediatR;
using SampleForTest.Common;

namespace Command.Application.Countries.Service.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, ResultDto<long>>
    {
        public Task<ResultDto<long>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
