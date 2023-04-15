using MediatR;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Application.Sensors.Commands;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Sensors.Handlers
{
    internal sealed class UpdateSensorCommandHandler : IRequestHandler<UpdateSensorCommand>
    {
        private readonly ISensorsRepository _repository;

        public UpdateSensorCommandHandler(ISensorsRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
        {
            var sensor = new Sensor(request.Id, request.Name);
            return _repository.UpdateAsync(sensor);
        }
    }
}
