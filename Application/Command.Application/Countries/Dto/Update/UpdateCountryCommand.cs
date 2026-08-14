using Command.Application.Countries.Dto.Create;
using MediatR;
using SampleTechnologyForTest.Common;

namespace Command.Application.Countries.Dto.Update
{
    public class UpdateCountryCommand : CreateCountryCommand, IRequest<ResultDto<long>>
    {
        public long CountryId { get; set; }
    }
}
