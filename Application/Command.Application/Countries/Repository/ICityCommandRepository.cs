using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Repository
{
    public interface ICityCommandRepository
    {
        Task Create(City command, CancellationToken cancellationToken);
        void Update(City command);
        void Delete(City command);

        City? FindById(long cityId);
    }
}
