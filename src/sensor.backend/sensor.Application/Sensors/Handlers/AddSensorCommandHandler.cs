using MediatR;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Sensors.Commands;
using sensor.Domain.Models;

namespace sensor.Application.Sensors.Handlers
{
    public class AddSensorCommandHandler : IRequestHandler<AddSensorCommand>
    {
        private readonly ISensorsRepository _repository;

        public AddSensorCommandHandler(ISensorsRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddSensorCommand request, CancellationToken cancellationToken)
        {
            var sensor = new Sensor() { Id = request.Id, Name = request.Name };

            return _repository.AddSensorAsync(sensor);
        }
    }
}
