using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Articles;

namespace Command.Persistence.ArticleConfigs.Config
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable(TableNameResource.Article);

            builder.HasKey(x => x.Id);

            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Body).IsRequired(true);
            builder.Property(a => a.Description).IsRequired(true);
            builder.Property(a => a.Tag).IsRequired(true);

            builder.HasOne(_ => _.ArticleCategory)
                   .WithMany(x => x.Articles)
                   .HasForeignKey(x => x.ArticleCategoryId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(true);
        }
    }
}
