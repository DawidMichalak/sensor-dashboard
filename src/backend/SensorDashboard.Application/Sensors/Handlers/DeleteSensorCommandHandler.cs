using MediatR;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Application.Sensors.Commands;

namespace SensorDashboard.Application.Sensors.Handlers
{
    internal sealed class DeleteSensorCommandHandler : IRequestHandler<DeleteSensorCommand>
    {
        private readonly ISensorsRepository _repository;

        public DeleteSensorCommandHandler(ISensorsRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteSensorCommand request, CancellationToken cancellationToken)
        {
            return _repository.DeleteAsync(request.Id);
        }
    }
}
