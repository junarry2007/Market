using MarketPlus.Application.Abstractions.Clock;
using MarketPlus.Domain.Abstractions;
using MarketPlus.Domain.Products;
using MarketPlus.Infrastructure.Clock;
using MarketPlus.Infrastructure.Contexts;
using MarketPlus.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlus.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            //Add context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultSqlite"));
            });

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

            return services;
        }

    }
}
