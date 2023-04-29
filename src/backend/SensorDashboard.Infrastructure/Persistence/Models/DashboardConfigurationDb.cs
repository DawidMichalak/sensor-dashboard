using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SensorDashboard.Infrastructure.Persistence.Models
{
    public sealed class DashboardConfigurationDb
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public List<ConfigurationItemDb> ConfigurationItems { get; set; }
    }
}
