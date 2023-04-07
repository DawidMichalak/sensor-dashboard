using MediatR;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Queries;

namespace sensor.Application.Readings.Handlers
{
    public class GetReadingsQueryHandler : IRequestHandler<GetReadingsQuery, IEnumerable<ReadingsDto>>
    {
        private readonly IReadingsRepository _readingsRepository;

        public GetReadingsQueryHandler(IReadingsRepository readingsRepository)
        {
            _readingsRepository = readingsRepository;
        }

        public async Task<IEnumerable<ReadingsDto>> Handle(GetReadingsQuery request, CancellationToken cancellationToken)
        {
            return await _readingsRepository.GetReadingsAsync();
        }
    }
}
