using MongoDB.Bson;
using MongoDB.Driver;
using sensor.Application.Contracts;
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

        public async Task<IEnumerable<ReadingsDto>> GetReadings()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$project",
                new BsonDocument
                    {
                        { "value",
                new BsonDocument("$round",
                new BsonArray
                            {
                                "$value",
                                1
                            }) },
                        { "timestamp", 1 },
                        { "metadata", 1 }
                    }),
                new BsonDocument("$group",
                new BsonDocument
                    {
                        { "_id",
                new BsonDocument
                        {
                            { "sensorId", "$metadata.sensorId" },
                            { "type", "$metadata.type" }
                        } },
                        { "values",
                new BsonDocument("$push", "$value") },
                        { "timestamps",
                new BsonDocument("$push", "$timestamp") },
                        { "maxValue",
                new BsonDocument("$max", "$value") },
                        { "minValue",
                new BsonDocument("$min", "$value") }
                    }),
                new BsonDocument("$project",
                new BsonDocument
                    {
                        { "_id", 0 },
                        { "sensorId", "$_id.sensorId" },
                        { "type", "$_id.type" },
                        { "values", 1 },
                        { "timestamps", 1 },
                        { "maxValue", 1 },
                        { "minValue", 1 }
                    })
            };

            var readings = await _collection.Aggregate<ReadingsDto>(pipeline).ToListAsync();

            return readings;
        }

        public Task AddReading(Reading reading)
        {
            return _collection.InsertOneAsync(reading);
        }
    }
}
