using MediatR;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Application.Readings.Commands;

namespace SensorDashboard.Application.Readings.Handlers
{
    internal sealed class AddReadingCommandHandler : IRequestHandler<AddReadingCommand>
    {
        private readonly IReadingsRepository _readingsRepository;

        public AddReadingCommandHandler(IReadingsRepository readingsRepository)
        {
            _readingsRepository = readingsRepository;
        }

        public Task Handle(AddReadingCommand request, CancellationToken cancellationToken)
        {
            return _readingsRepository.AddReadingAsync(request.Reading);
        }
    }
}
