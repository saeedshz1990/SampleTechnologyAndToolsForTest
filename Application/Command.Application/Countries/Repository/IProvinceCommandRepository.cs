using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Application.Countries.Repository
{
    public interface IProvinceCommandRepository
    {
        Task Create(Province command, CancellationToken cancellationToken);
        void Update(Province command);
        void Delete(Province command);

        Province? FindById(long ProvinceId);
    }
}
