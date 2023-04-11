using MediatR;
using sensor.Application.Contracts;

namespace sensor.Application.Readings.Queries
{
    public class GetReadingsQuery : IRequest<IEnumerable<ReadingsDto>>
    {
        public DateTime BeginDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}
