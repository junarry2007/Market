using FluentValidation;
using MarketPlus.Application.Abstractions.Behaviors;
using MarketPlus.Domain.Products;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlus.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddTransient<ProductService>();

            return services;
        }
    }
}
