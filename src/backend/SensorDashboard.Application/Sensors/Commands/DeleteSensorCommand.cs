using MediatR;

namespace SensorDashboard.Application.Sensors.Commands
{
    public class DeleteSensorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
