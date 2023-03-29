using MongoDB.Driver;
using sensor.Application.Contracts.Persistence;
using sensor.Domain.Models;
using System.Linq.Expressions;

namespace sensor.Infrastructure.Persistence.Repositories
{
    public class ReadingsRepository : IReadingsRepository
    {
        private readonly IMongoCollection<Reading> _collection;

        public ReadingsRepository(MongoDbClient dbClient)
        {
            _collection = dbClient.Database.GetCollection<Reading>("readings");
        }

        public async Task<IEnumerable<Reading>> GetReadings(Expression<Func<Reading, bool>> filter)
        {
            var readings = await _collection.Find(filter).ToListAsync();

            return readings;
        }

        public async Task AddReading(Reading reading)
        {
            await _collection.InsertOneAsync(reading);
        }
    }
}
