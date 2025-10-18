using MediatR;
using SampleForTest.Common;

namespace Command.Application.Countries.Dto.CreateCity
{
    public class CreateCityCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public long ProvinceId { get; set; }
        public long CountryId { get; set; }
    }
}
