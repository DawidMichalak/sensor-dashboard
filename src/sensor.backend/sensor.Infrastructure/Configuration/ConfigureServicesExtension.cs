
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sensor.Infrastructure.Persistence;
using sensor.Infrastructure.Persistence.Repositories;

namespace sensor.Infrastructure.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoDbClient>();
            services.AddScoped<ReadingsRepository>();

            return services;
        }
    }
}
