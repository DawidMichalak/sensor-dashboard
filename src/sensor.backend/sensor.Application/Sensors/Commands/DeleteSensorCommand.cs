using MediatR;

namespace sensor.Application.Sensors.Commands
{
    public class DeleteSensorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
