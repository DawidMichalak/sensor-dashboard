using sensor.Api.Messaging.Processing;

namespace sensor.Api.Messaging
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
