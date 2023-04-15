using MediatR;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Application.Sensors.Commands;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Sensors.Handlers
{
    internal sealed class AddSensorCommandHandler : IRequestHandler<AddSensorCommand>
    {
        private readonly ISensorsRepository _repository;

        public AddSensorCommandHandler(ISensorsRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddSensorCommand request, CancellationToken cancellationToken)
        {
            var sensor = new Sensor(request.Id, request.Name);
            return _repository.AddSensorAsync(sensor);
        }
    }
}
