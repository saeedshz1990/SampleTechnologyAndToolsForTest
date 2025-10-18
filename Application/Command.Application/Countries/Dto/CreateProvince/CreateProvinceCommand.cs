using MediatR;
using SampleForTest.Common;

namespace Command.Application.Countries.Dto.CreateProvince
{
    public class CreateProvinceCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public long CountryId { get; set; }
    }
}
