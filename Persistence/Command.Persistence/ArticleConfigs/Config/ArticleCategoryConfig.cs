using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Persistence.ArticleConfigs.Config
{
    public class ArticleCategoryConfig : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable(TableNameResource.ArticleCategory);

            builder.HasKey(x => x.Id);

            builder.Property(_=>_.Title).IsRequired(true);
            builder.Property(_=>_.Description).IsRequired(true);
        }
    }
}
