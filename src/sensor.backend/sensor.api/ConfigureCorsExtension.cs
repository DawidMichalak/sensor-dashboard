namespace sensor.api
{
    public static class ConfigureCorsExtension
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration, string policyName)
        {
            var origins = configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddPolicy(policyName, builder =>
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(origins)
                    .AllowCredentials()
                );
            });

            return services;
        }
    }
}
