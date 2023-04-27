namespace SensorDashboard.Domain.Models
{
    public sealed class ConfigurationItem
    {
        public string? Id { get; set; }
        public string Name { get; }
        public int SensorId { get; }

        public ConfigurationItem(string name, int sensorId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            Name = name;
            SensorId = sensorId;
        }
    }
}
