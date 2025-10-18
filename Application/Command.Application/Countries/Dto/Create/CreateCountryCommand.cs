using MediatR;
using SampleForTest.Common;

namespace Command.Application.Countries.Dto.Create
{
    public class CreateCountryCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }
}
