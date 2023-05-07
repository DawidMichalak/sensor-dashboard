namespace SensorDashboard.Api.Requests
{
    public sealed class UpdateConfigurationItemRequest
    {
        public string Name { get; set; }
        public int SensorId { get; set; }
    }
}
