using Microsoft.EntityFrameworkCore;
using Query.Application.Articles.QueryResult;

namespace Query.Persistence.Common
{
    public class SampleQueryContext : DbContext
    {
        public SampleQueryContext(DbContextOptions<SampleQueryContext> options) : base(options)
        {
        }
        public DbSet<ArticleQr> Articles { get; set; }
    }
}
