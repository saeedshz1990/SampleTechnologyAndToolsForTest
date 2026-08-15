using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Query.Persistence.Common;

namespace Query.Persistence
{
    public class SampleQueryContextFactory : IDesignTimeDbContextFactory<SampleQueryContext>
    {
        public SampleQueryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleQueryContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=SampleTechnologyForTestQuery;Username=postgres;Password=YourStrong!Passw0rd;Include Error Detail=true");

            return new SampleQueryContext(optionsBuilder.Options);
        }
    }
}
