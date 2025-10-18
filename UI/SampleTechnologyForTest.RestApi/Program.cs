using Command.Application;
using Command.Application.Articles.Dto.CreateArticleCategory;
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
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Query.Persistence.Common;
using SampleTechnologyForTest.Infrastructure;
using SampleTechnologyForTest.Logging;
using SampleTechnologyForTest.Logging.MongoLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//read CommandDB Connectionstring==>Sql Server
builder.Services.AddDbContext<SampleCommandContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommandDBConnection")));

//read Query Connection string ==>Postgres
builder.Services.AddDbContext<SampleQueryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("QueryDBConnection")));

//Read Redis ConnetionString
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
});

//------------------------------MongoDb Config--------//
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});
builder.Services.AddScoped<AuditLogService>(); // 👈 سرویس اصلی

//----------------------------------------//

//Resolve MediatR
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(CreateArticleCategoryCommand).Assembly));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IArticleCategoryCommandRepository, ArticleCategoryCommandRepository>();
builder.Services.AddScoped<IArticleCommandRepository, ArticleCommandRepository>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
builder.Services.AddScoped<IOrderItemCommandRepository, OrderItemCommandRepository>();
builder.Services.AddScoped<ICountryCommandRepository, CountryCommandRepository>();
builder.Services.AddScoped<IProvinceCommandRepository, ProvinceCommandRepository>();
builder.Services.AddScoped<ICityCommandRepository, CityCommandRepository>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
