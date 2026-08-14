using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Countries.Dto.DeleteCity
{
    public class DeleteCityCommand : IRequest<ResultDto<long>>
    {
        public long CityId { get; set; }
        public long ProvinceId { get; set; }
        public long CountryId{ get; set; }
    }
}
