using Command.Application.Countries.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Persistence.CountryConfigs.Repository
{
    public class CountryCommandRepository : ICountryCommandRepository
    {
        private readonly SampleCommandContext _context;

        public CountryCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public async Task Create(Country command, CancellationToken cancellationToken)
        {
            await _context.Countries.AddAsync(command, cancellationToken).ConfigureAwait(true);
        }

        public void Delete(Country command)
        {
            _context.Countries.Remove(command);
        }

        public Country? FindById(long CountryId)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == CountryId);
        }

        public void Update(Country command)
        {
            _context.Countries.Update(command);
        }
    }
}
