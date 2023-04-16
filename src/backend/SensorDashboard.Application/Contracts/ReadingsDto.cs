namespace SensorDashboard.Application.Contracts
{
    public class ReadingsDto
    {
        public double[] Values { get; init; }
        public double MaxValue { get; init; }
        public double MinValue { get; init; }
        public string Type { get; init; }
        public int SensorId { get; init; }
        public DateTime[] Timestamps { get; init; }
    }
}
