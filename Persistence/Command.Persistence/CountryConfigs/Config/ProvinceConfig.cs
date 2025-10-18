using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Countries;

namespace Command.Persistence.CountryConfigs.Config
{
    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable(TableNameResource.Province);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired(true);

            builder.HasMany(p => p.Cities)
                   .WithOne(p => p.Province)
                   .HasForeignKey(p => p.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(true);
        }
    }
}
