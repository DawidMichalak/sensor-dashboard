namespace sensor.Domain.Models
{
    public class Reading
    {
        public string? Id { get; init; }
        public float Value { get; init; }
        public DateTime Timestamp { get; init; }
        public ReadingMetadata Metadata { get; init; }
    }
}
