using MediatR;

namespace sensor.Application.Sensors.Commands
{
    public class UpdateSensorCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
