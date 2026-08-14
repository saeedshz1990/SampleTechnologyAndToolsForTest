using Command.Application.Articles.Dto.CreateArticleCategory;
using Microsoft.Extensions.DependencyInjection;

namespace Command.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommandApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(
                    typeof(CreateArticleCategoryCommand).Assembly));

            return services;
        }
    }
}
