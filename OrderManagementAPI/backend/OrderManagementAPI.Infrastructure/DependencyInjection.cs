using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Infrastructure.Persistence;
using OrderManagementAPI.Infrastructure.Repositories;

namespace OrderManagementAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
