using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Persistence.CountryConfigs.Config
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(TableNameResource.City);

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Title).IsRequired(true);
        }
    }
}
