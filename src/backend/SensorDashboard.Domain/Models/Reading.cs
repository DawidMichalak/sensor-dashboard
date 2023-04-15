namespace SensorDashboard.Domain.Models
{
    public class Reading
    {
        public string? Id { get; init; }
        public double Value { get; init; }
        public DateTime Timestamp { get; init; }
        public ReadingMetadata Metadata { get; init; }
    }
}
