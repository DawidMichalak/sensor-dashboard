﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Domain.Models;
using SensorDashboard.Infrastructure.Persistence;
using SensorDashboard.Infrastructure.Persistence.Repositories;

namespace SensorDashboard.Infrastructure.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ConfigureServicesExtension).Assembly);

            AddMongoDb(services, configuration);

            return services;
        }

        private static void AddMongoDb(IServiceCollection services, IConfiguration configuration)
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention()
            };

            ConventionRegistry.Register("Camel case convention", pack, t => true);

            BsonClassMap.RegisterClassMap<Reading>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetSerializer(new StringSerializer(BsonType.ObjectId)).SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<Sensor>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(s => new Sensor(s.Id, s.Name));
            });

            services.AddSingleton<MongoDbClient>();
            services.AddScoped<IReadingsRepository, ReadingsRepository>();
            services.AddScoped<ISensorsRepository, SensorsRepository>();
            services.AddScoped<IConfigurationsRepository, ConfigurationsRepository>();
        }
    }
}
