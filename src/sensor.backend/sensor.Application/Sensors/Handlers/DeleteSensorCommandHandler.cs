using MediatR;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Sensors.Commands;

namespace sensor.Application.Sensors.Handlers
{
    public class DeleteSensorCommandHandler : IRequestHandler<DeleteSensorCommand>
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
