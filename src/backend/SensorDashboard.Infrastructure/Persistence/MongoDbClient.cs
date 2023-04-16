using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SensorDashboard.Infrastructure.Configuration;

namespace SensorDashboard.Infrastructure.Persistence
{
    public class MongoDbClient
    {
        public IMongoDatabase Database { get; init; }

        public MongoDbClient(IOptions<MongoDbConfiguration> options)
        {
            var client = new MongoClient(options.Value.ConnectionURI);
            Database = client.GetDatabase(options.Value.DatabaseName);
        }
    }
}
