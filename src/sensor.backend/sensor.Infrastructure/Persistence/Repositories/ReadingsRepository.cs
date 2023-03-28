using MongoDB.Driver;
using sensor.Application.Contracts.Persistence;

namespace sensor.Infrastructure.Persistence.Repositories
{
    public class ReadingsRepository : IReadingsRepository
    {
        private readonly IMongoDatabase _database;

        public ReadingsRepository(MongoDbClient dbClient)
        {
            _database = dbClient.Database;
        }
    }
}
