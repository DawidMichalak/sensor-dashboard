using MediatR;
using sensor.Domain.Models;

namespace sensor.Application.Sensors.Queries
{
    public class GetSensorsQuery : IRequest<IEnumerable<Sensor>>
    {
    }
}
