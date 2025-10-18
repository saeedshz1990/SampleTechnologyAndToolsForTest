using Command.Application.Countries.Repository;
using Command.Persistence.Common;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Persistence.CountryConfigs.Repository
{
    public class ProvinceCommandRepository : IProvinceCommandRepository
    {
        private readonly SampleCommandContext _context;

        public ProvinceCommandRepository(SampleCommandContext context)
        {
            _context = context;
        }

        public async Task Create(Province command, CancellationToken cancellationToken)
        {
            await _context.Provinces.AddAsync(command, cancellationToken).ConfigureAwait(true);
        }

        public void Delete(Province command)
        {
            _context.Provinces.Remove(command);
        }

        public Province? FindById(long ProvinceId)
        {
            return _context.Provinces.FirstOrDefault(_ => _.Id == ProvinceId);
        }

        public void Update(Province command)
        {
            _context.Provinces.Update(command);
        }
    }
}
