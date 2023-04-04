using MediatR;
using sensor.Application.Commands;
using sensor.Application.Contracts.Persistence;

namespace sensor.Application.Handlers
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
            return _readingsRepository.AddReading(request.Reading);
        }
    }
}
