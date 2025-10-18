using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Repository
{
    public interface ICountryCommandRepository
    {
        Task Create(Country command, CancellationToken cancellationToken);
        void Update(Country command);
        void Delete(Country command);

        Country? FindById(long CountryId);
    }
}
