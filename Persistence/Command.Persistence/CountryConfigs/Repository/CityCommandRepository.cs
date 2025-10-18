using Command.Application.Countries.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Persistence.CountryConfigs.Repository
{
    public class CityCommandRepository : ICityCommandRepository
    {
        private readonly SampleCommandContext _context;

        public CityCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public async Task Create(City command, CancellationToken cancellationToken)
        {
            await _context.Cities.AddAsync(command, cancellationToken);
        }

        public void Delete(City command)
        {
            _context.Cities.Remove(command);
        }

        public City? FindById(long cityId)
        {
            return _context.Cities.FirstOrDefault(_ => _.Id == cityId);
        }

        public void Update(City command)
        {
            _context.Cities.Update(command);
        }
    }
}
