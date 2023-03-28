
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace sensor.Infrastructure
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }
    }
}
