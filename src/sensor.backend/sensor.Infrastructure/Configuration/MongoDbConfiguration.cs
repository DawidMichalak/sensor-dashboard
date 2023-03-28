namespace sensor.Infrastructure.Configuration
{
    public class MongoDbConfiguration
    {
        public string ConnectionURI { get; init; } = string.Empty;
        public string DatabaseName { get; init; } = string.Empty;
    }
}
