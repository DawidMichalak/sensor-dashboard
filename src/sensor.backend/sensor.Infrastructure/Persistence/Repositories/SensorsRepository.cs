using MongoDB.Driver;
using sensor.Application.Contracts.Persistence;
using sensor.Domain.Models;
using System.Linq.Expressions;

namespace sensor.Infrastructure.Persistence.Repositories
{
    public class SensorsRepository : ISensorsRepository
    {
        private readonly IMongoCollection<Sensor> _collection;

        public SensorsRepository(MongoDbClient dbClient)
        {
            _collection = dbClient.Database.GetCollection<Sensor>("sensors");
        }

        public async Task<IEnumerable<Sensor>> GetSensorsAsync()
        {
            var filter = Builders<Sensor>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Sensor>> GetSensorsWhereAsync(Expression<Func<Sensor, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public Task AddSensorAsync(Sensor sensor)
        {
            return _collection.InsertOneAsync(sensor);
        } 

        public Task UpdateAsync(Sensor sensor)
        {
            return _collection.ReplaceOneAsync((x) => x.Id == sensor.Id, sensor);
        }

        public Task DeleteAsync(int sensorId)
        {
            return _collection.DeleteOneAsync((x) => x.Id == sensorId);
        }
    }
}
