using Microsoft.EntityFrameworkCore;
using Query.Application.Articles.QueryResult;
using Query.Application.Products.QueryResult;

namespace Query.Persistence.Common
{
    public class SampleQueryContext : DbContext
    {
        public SampleQueryContext(DbContextOptions<SampleQueryContext> options) : base(options)
        {
        }
        public DbSet<ArticleQr> Articles { get; set; }
        public DbSet<ProductQr> Products { get; set; }

    }
}
