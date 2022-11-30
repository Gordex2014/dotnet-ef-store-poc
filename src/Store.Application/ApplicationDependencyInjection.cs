using Microsoft.Extensions.DependencyInjection;
using Store.Application.Services;
using Store.Application.Services.Contracts;

namespace Store.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
