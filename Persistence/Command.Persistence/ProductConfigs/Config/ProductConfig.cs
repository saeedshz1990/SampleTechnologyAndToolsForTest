using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Products;

namespace Command.Persistence.ProductConfigs.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNameResource.Product);

            builder.HasKey(x => x.Id);

            builder.Property(_ => _.Title).IsRequired(true);
            builder.Property(_ => _.Description).IsRequired(true);

        }
    }
}
