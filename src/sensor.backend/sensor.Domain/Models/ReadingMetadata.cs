namespace sensor.Domain.Models
{
    public class ReadingMetadata
    {
        public int SensorId { get; init; }
        public string Type { get; init; } = string.Empty;
    }
}
