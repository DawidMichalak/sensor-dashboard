using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Domain.Models;
using SensorDashboard.Infrastructure.Persistence.Models;

namespace SensorDashboard.Infrastructure.Persistence.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly IMongoCollection<DashboardConfigurationDb> _collection;
        private readonly IMapper _mapper;

        public ConfigurationsRepository(MongoDbClient dbClient, IMapper mapper)
        {
            _collection = dbClient.Database.GetCollection<DashboardConfigurationDb>("configurations");
            _mapper = mapper;
        }

        public async Task<DashboardConfiguration> GetAsync(string id)
        {
            var configurationdb = await _collection.Find(x => x.Id.ToString() == id).FirstOrDefaultAsync();

            var configuration = _mapper.Map<DashboardConfiguration>(configurationdb);

            return configuration;
        }

        public async Task<DashboardConfiguration> AddAsync(DashboardConfiguration configuration)
        {
            var configurationdb = _mapper.Map<DashboardConfigurationDb>(configuration);

            await _collection.InsertOneAsync(configurationdb);
            return configuration;
        }

        public async Task<ConfigurationItem> AddConfigurationItemAsync(string dashboardId, ConfigurationItem item)
        {
            var configurationDb = _mapper.Map<ConfigurationItemDb>(item);
            configurationDb.Id = ObjectId.GenerateNewId();
            item.Id = configurationDb.Id.ToString();

            var update = Builders<DashboardConfigurationDb>.Update.Push(c => c.ConfigurationItems, configurationDb);
            await _collection.UpdateOneAsync(d => d.Id.ToString() == dashboardId, update);
            return item;
        }

        public async Task UpdateConfigurationItemAsync(string dashboardId, ConfigurationItem item)
        {
            var mappedItem = _mapper.Map<ConfigurationItemDb>(item);
            var configurationId = ObjectId.Parse(dashboardId);

            var filter = Builders<DashboardConfigurationDb>.Filter.Eq(x => x.Id, configurationId)
                       & Builders<DashboardConfigurationDb>.Filter.ElemMatch(x => x.ConfigurationItems, Builders<ConfigurationItemDb>.Filter.Eq(x => x.Id, mappedItem.Id));

            var update = Builders<DashboardConfigurationDb>.Update.Set(x => x.ConfigurationItems.FirstMatchingElement(), mappedItem);

            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task RemoveConfigurationItemAsync(string dashboardId, string ItemId)
        {
            var configurationId = ObjectId.Parse(dashboardId);
            var configurationItemId = ObjectId.Parse(ItemId);

            var filter = Builders<DashboardConfigurationDb>.Filter.Eq(x => x.Id, configurationId);
            var update = Builders<DashboardConfigurationDb>.Update.PullFilter(d => d.ConfigurationItems, Builders<ConfigurationItemDb>.Filter.Eq(x => x.Id, configurationItemId));

            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
