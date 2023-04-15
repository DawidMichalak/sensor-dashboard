using SensorDashboard.Api.Messaging.Processing;

namespace SensorDashboard.Api.Messaging
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddScoped<ISensorMessageProcessor, SensorMessageProcessor>();
            services.AddHostedService<QueueConsumer>();
            return services;
        }
    }
}
