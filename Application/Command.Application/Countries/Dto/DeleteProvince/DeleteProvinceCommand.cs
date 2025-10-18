using MediatR;
using SampleForTest.Common;

namespace Command.Application.Countries.Dto.DeleteProvince
{
    public class DeleteProvinceCommand : IRequest<ResultDto<long>>
    {
        public long ProvinceId { get; set; }
    }
}
