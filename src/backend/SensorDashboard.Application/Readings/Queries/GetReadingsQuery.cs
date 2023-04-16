using MediatR;
using SensorDashboard.Application.Contracts;

namespace SensorDashboard.Application.Readings.Queries
{
    public class GetReadingsQuery : IRequest<IEnumerable<ReadingsDto>>
    {
        public DateTime BeginDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}
