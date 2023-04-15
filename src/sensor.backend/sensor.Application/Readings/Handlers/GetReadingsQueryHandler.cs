using MediatR;
using Microsoft.Extensions.Caching.Memory;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Queries;
using sensor.Domain.Exceptions;

namespace sensor.Application.Readings.Handlers
{
    internal sealed class GetReadingsQueryHandler : IRequestHandler<GetReadingsQuery, IEnumerable<ReadingsDto>>
    {
        private readonly IReadingsRepository _readingsRepository;
        private readonly IMemoryCache _cache;

        public GetReadingsQueryHandler(IReadingsRepository readingsRepository, IMemoryCache cache)
        {
            _readingsRepository = readingsRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<ReadingsDto>> Handle(GetReadingsQuery request, CancellationToken cancellationToken)
        {
            if (request.BeginDate > request.EndDate)
            {
                throw new InvalidDateRangeException();
            }

            var cacheKey = $"readings:{request.BeginDate:yyyyMMdd}-{request.EndDate:yyyyMMdd}";
            if (_cache.TryGetValue(cacheKey, out IEnumerable<ReadingsDto> cachedResult))
            {
                return cachedResult;
            }

            var repositoryReadings = await _readingsRepository.GetAllReadingsAsync(request.BeginDate, request.EndDate);

            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _cache.Set(cacheKey, repositoryReadings, cacheOptions);

            return repositoryReadings;
        }
    }
}
