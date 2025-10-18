using MediatR;
using SampleForTest.Common;

namespace Command.Application.Countries.Dto.Delete
{
    public class DeleteCountryCommand : IRequest<ResultDto<long>>
    {
        public long CountryId { get; set; }
    }
}
