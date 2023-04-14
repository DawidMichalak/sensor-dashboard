using MediatR;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Queries;
using sensor.Domain.Exceptions;

namespace sensor.Application.Readings.Handlers
{
    internal sealed class GetReadingsQueryHandler : IRequestHandler<GetReadingsQuery, IEnumerable<ReadingsDto>>
    {
        private readonly IReadingsRepository _readingsRepository;

        public GetReadingsQueryHandler(IReadingsRepository readingsRepository)
        {
            _readingsRepository = readingsRepository;
        }

        public async Task<IEnumerable<ReadingsDto>> Handle(GetReadingsQuery request, CancellationToken cancellationToken)
        {
            if (request.BeginDate > request.EndDate)
            {
                throw new InvalidDateRangeException();
            }

            return await _readingsRepository.GetAllReadingsAsync(request.BeginDate, request.EndDate);
        }
    }
}
