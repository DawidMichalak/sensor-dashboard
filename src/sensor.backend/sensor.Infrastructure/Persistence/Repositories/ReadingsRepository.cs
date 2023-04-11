using MongoDB.Bson;
using MongoDB.Driver;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Domain.Models;

namespace sensor.Infrastructure.Persistence.Repositories
{
    public class ReadingsRepository : IReadingsRepository
    {
        private readonly IMongoCollection<Reading> _collection;

        public ReadingsRepository(MongoDbClient dbClient)
        {
            _collection = dbClient.Database.GetCollection<Reading>("readings");
        }

        public async Task<IEnumerable<ReadingsDto>> GetAllReadingsAsync(DateTime beginDate, DateTime endDate)
        {
            var pipeline = GetAggregationStages();
            AddDateFilter(pipeline, beginDate, endDate);

            var readings = await _collection.Aggregate<ReadingsDto>(pipeline.ToArray()).ToListAsync();

            return readings;
        }

        public async Task<ReadingsDto> GetReadingsAsync(DateTime beginDate, DateTime endDate, int sensorId)
        {
            var pipeline = GetAggregationStages();
            AddDateFilter(pipeline, beginDate, endDate);
            AddSensorFilter(pipeline, sensorId);

            var readings = await _collection.Aggregate<ReadingsDto>(pipeline.ToArray()).FirstOrDefaultAsync();

            return readings;
        }

        public Task AddReadingAsync(Reading reading)
        {
            return _collection.InsertOneAsync(reading);
        }

        private LinkedList<BsonDocument> GetAggregationStages()
        {
            var stages = new BsonDocument[]
            {
                new BsonDocument("$sort",
                    new BsonDocument("timestamp", 1)),
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
            return new LinkedList<BsonDocument>(stages);
        }

        private void AddDateFilter(LinkedList<BsonDocument> stages, DateTime beginDate, DateTime endDate)
        {
            stages.AddFirst(
                new BsonDocument("$match",
                    new BsonDocument("timestamp",
                        new BsonDocument
                        {
                            { "$gt", beginDate },
                            { "$lt", endDate }
                        })
                    )
                );
        }

        private void AddSensorFilter(LinkedList<BsonDocument> stages, int sensorId)
        {
            stages.AddFirst(
                new BsonDocument("$match",
                    new BsonDocument("metadata.sensorId", sensorId)
                    )
                );
        }
    }
}
