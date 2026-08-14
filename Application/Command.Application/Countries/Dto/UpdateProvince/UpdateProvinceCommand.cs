using Command.Application.Countries.Dto.CreateProvince;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Countries.Dto.UpdateProvince
{
    public class UpdateProvinceCommand : IRequest<ResultDto<long>>
    {
        public long ProvinceId { get; set; }
        public long CountryId { get; set; }
        public string Title { get; set; }=string.Empty;
    }
}
