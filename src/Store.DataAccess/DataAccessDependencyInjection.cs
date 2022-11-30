using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DataAccess.Persistence;
using Store.DataAccess.Repositories;
using Store.DataAccess.Repositories.Contracts;

namespace Store.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            services.AddRepositories();

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPartRepository, PartRepository>();
            services.AddScoped<IProductPartRepository, ProductPartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options =>
                options.UseLazyLoadingProxies().UseNpgsql(connectionString, options => 
                options.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
        }
    }
}
