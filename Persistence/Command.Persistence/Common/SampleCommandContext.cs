using Microsoft.EntityFrameworkCore;
using SampleTechnologyForTest.Entities.Entity.Articles;
using SampleTechnologyForTest.Entities.Entity.Categories;
using SampleTechnologyForTest.Entities.Entity.Countries;
using SampleTechnologyForTest.Entities.Entity.Orders;
using SampleTechnologyForTest.Entities.Entity.Outbox;
using SampleTechnologyForTest.Entities.Entity.Products;

namespace Command.Persistence.Common
{
    public class SampleCommandContext : DbContext
    {
        public SampleCommandContext(DbContextOptions<SampleCommandContext> options) : base(options)
        {
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
    }
}
