using MediatR;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Sensors.Commands;
using sensor.Domain.Models;

namespace sensor.Application.Sensors.Handlers
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
