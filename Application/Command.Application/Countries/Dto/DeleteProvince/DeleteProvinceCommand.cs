using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Countries.Dto.DeleteProvince
{
    public class DeleteProvinceCommand : IRequest<ResultDto<long>>
    {
        public long ProvinceId { get; set; }
    }
}
