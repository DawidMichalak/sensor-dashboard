using MediatR;
using sensor.Application.Contracts;

namespace sensor.Application.Readings.Queries
{
    public class GetSensorReadingsQuery : IRequest<ReadingsDto>
    {
        public int SensorId { get; init; }
        public DateTime BeginDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}