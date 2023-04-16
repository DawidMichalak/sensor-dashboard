using MediatR;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Sensors.Queries
{
    public class GetSensorsQuery : IRequest<IEnumerable<Sensor>>
    {
    }
}
