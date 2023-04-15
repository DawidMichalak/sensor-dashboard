using MediatR;
using Microsoft.Extensions.Caching.Memory;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Queries;

namespace sensor.Application.Readings.Handlers
{
    internal sealed class GetSensorReadingsQueryHandler : IRequestHandler<GetSensorReadingsQuery, ReadingsDto>
    {
        private readonly IReadingsRepository _readingsRepository;
        private readonly IMemoryCache _cache;
        private string _cacheKey;

        public GetSensorReadingsQueryHandler(IReadingsRepository readingsRepository, IMemoryCache cache)
        {
            _readingsRepository = readingsRepository;
            _cache = cache;
            _cacheKey = string.Empty;
        }

        public async Task<ReadingsDto> Handle(GetSensorReadingsQuery request, CancellationToken cancellationToken)
        {
            if (request.BeginDate > request.EndDate)
            {
                throw new Exception();
            }

            _cacheKey = $"readings:{request.BeginDate:yyyyMMdd}-{request.EndDate:yyyyMMdd}-{request.SensorId}";
            var cachedReadings = GetCachedResults(request);
            if (cachedReadings != null)
            {
                return cachedReadings;
            }

            var readings = await _readingsRepository.GetReadingsAsync(request.BeginDate, request.EndDate, request.SensorId);

            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _cache.Set(_cacheKey, readings, cacheOptions);

            return readings;
        }

        private ReadingsDto? GetCachedResults(GetSensorReadingsQuery request)
        {
            var collectionCacheKey = $"readings:{request.BeginDate:yyyyMMdd}-{request.EndDate:yyyyMMdd}";
            if (_cache.TryGetValue(collectionCacheKey, out IEnumerable<ReadingsDto> cachedCollection))
            {
                return cachedCollection?.Where(r => r.SensorId == request.SensorId).FirstOrDefault();
            }

            if (_cache.TryGetValue(_cacheKey, out ReadingsDto cachedResult))
            {
                return cachedResult;
            }

            return null;
        }
    }
}
