using MediatR;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Commands;

namespace sensor.Application.Readings.Handlers
{
    public class AddReadingCommandHandler : IRequestHandler<AddReadingCommand>
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
