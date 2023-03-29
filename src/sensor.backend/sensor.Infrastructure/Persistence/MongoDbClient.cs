using Microsoft.Extensions.Options;
using MongoDB.Driver;
using sensor.Infrastructure.Configuration;

namespace sensor.Infrastructure.Persistence
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
