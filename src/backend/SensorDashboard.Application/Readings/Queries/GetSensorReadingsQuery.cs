using MediatR;
using SensorDashboard.Application.Contracts;

namespace SensorDashboard.Application.Readings.Queries
{
    public class GetSensorReadingsQuery : IRequest<ReadingsDto>
    {
        public int SensorId { get; init; }
        public DateTime BeginDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}