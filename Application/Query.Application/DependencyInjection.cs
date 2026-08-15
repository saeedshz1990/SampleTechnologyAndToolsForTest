using Microsoft.Extensions.DependencyInjection;
using Query.Application.Products.Dto.GetAll;

namespace Query.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQueryApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly));

            return services;
        }
    }
}
