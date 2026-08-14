using Command.Application.Countries.Dto.CreateCity;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Countries.Dto.UpdateCity
{
    public class UpdateCityCommand : CreateCityCommand, IRequest<ResultDto<long>>
    {
        public long CityId { get; set; }
    }
}
