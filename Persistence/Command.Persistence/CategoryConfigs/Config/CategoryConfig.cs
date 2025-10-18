using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Categories;

namespace Command.Persistence.CategoryConfigs.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(TableNameResource.Category);

            builder.HasKey(c => c.Id);

            builder.Property(_ => _.Title).IsRequired(true);
            builder.Property(_ => _.Description).IsRequired(true);

            builder.HasMany(_ => _.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
