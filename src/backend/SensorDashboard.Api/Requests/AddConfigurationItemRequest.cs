namespace SensorDashboard.Api.Requests
{
    public sealed class AddConfigurationItemRequest
    {
        public string Name { get; set; }
        public int SensorId { get; set; }
    }
}
