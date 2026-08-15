using Command.Application;
using Command.Application.Articles.Repository;
using Command.Application.Categories.Repository;
using Command.Application.Countries.Repository;
using Command.Application.Orders.Repository;
using Command.Application.Products.Repository;
using Command.Persistence.ArticleConfigs.Repository;
using Command.Persistence.CategoryConfigs.Repository;
using Command.Persistence.Common;
using Command.Persistence.CountryConfigs.Repository;
using Command.Persistence.OrderConfigs.Repository;
using Command.Persistence.ProductConfigs.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Query.Application.Products.Repository;
using Query.Persistence.Common;
using Query.Persistence.ProductConfigs.Repository;
using SampleTechnologyForTest.Infrastructure.BackgroundServices;
using SampleTechnologyForTest.Logging;
using SampleTechnologyForTest.Logging.MongoLogging;

namespace SampleTechnologyForTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SampleCommandContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CommandDBConnection")));

            services.AddDbContext<SampleQueryContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("QueryDBConnection")));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration =
                    configuration.GetConnectionString("RedisConnection");
            });

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings =
                    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;

                return new MongoClient(settings.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(sp =>
            {
                var settings =
                    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;

                var client = sp.GetRequiredService<IMongoClient>();

                return client.GetDatabase(settings.DatabaseName);
            });

            services.AddScoped<AuditLogService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IArticleCategoryCommandRepository, ArticleCategoryCommandRepository>();
            services.AddScoped<IArticleCommandRepository, ArticleCommandRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
            services.AddScoped<IOrderItemCommandRepository, OrderItemCommandRepository>();
            services.AddScoped<ICountryCommandRepository, CountryCommandRepository>();
            services.AddScoped<IProvinceCommandRepository, ProvinceCommandRepository>();
            services.AddScoped<ICityCommandRepository, CityCommandRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddHostedService<OutboxProcessorService>();
            return services;
        }
    }
}