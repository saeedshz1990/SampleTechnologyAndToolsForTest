using Command.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Command.Persistence
{
    public class SampleCommandContextFactory
        : IDesignTimeDbContextFactory<SampleCommandContext>
    {
        public SampleCommandContext CreateDbContext(string[] args)
        {
            var optionsBuilder =
                new DbContextOptionsBuilder<SampleCommandContext>();

            optionsBuilder.UseSqlServer(
                "Server=.;Database=SampleTechnologyForTest;Trusted_Connection=True;TrustServerCertificate=True;");

            return new SampleCommandContext(optionsBuilder.Options);
        }
    }
}
