namespace sensor.Application.Contracts
{
    public class ReadingsDto
    {
        public int[] Values { get; init; }
        public int MaxValue { get; init; }
        public int MinValue { get; init; }
        public string Type { get; init; }
        public int SensorId { get; init; }
        public DateTime[] Timestamps { get; init; }
    }
}
