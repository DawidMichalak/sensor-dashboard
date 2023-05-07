namespace SensorDashboard.Domain.Models
{
    public sealed class DashboardConfiguration
    {
        public string? Id { get; set; }
        public IEnumerable<ConfigurationItem> ConfigurationItems { get; }

        public DashboardConfiguration(IEnumerable<ConfigurationItem> configurationItems)
        {
            ConfigurationItems = configurationItems;
        }
    }
}
