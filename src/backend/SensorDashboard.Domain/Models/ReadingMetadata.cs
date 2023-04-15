namespace SensorDashboard.Domain.Models
{
    public sealed class ReadingMetadata
    {
        public int SensorId { get; }
        public string Type { get; }

        public ReadingMetadata(int sensorId, string type)
        {
            if (sensorId <= 0)
            {
                throw new ArgumentException("Id must be a positive number", nameof(sensorId));
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Type cannot be null or empty", nameof(type));
            }

            SensorId = sensorId;
            Type = type;
        }
    }
}
