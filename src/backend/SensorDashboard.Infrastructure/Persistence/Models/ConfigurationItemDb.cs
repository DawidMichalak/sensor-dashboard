using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SensorDashboard.Infrastructure.Persistence.Models
{
    public sealed class ConfigurationItemDb
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public int SensorId { get; set; }
    }
}
