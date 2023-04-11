using MediatR;
using sensor.Application.Contracts;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Readings.Queries;

namespace sensor.Application.Readings.Handlers
{
    internal sealed class GetSensorReadingsQueryHandler : IRequestHandler<GetSensorReadingsQuery, ReadingsDto>
    {
        private readonly IReadingsRepository _readingsRepository;

        public GetSensorReadingsQueryHandler(IReadingsRepository readingsRepository)
        {
            _readingsRepository = readingsRepository;
        }

        public async Task<ReadingsDto> Handle(GetSensorReadingsQuery request, CancellationToken cancellationToken)
        {
            if (request.BeginDate > request.EndDate)
            {
                throw new Exception();
            }

            var readings = await _readingsRepository.GetReadingsAsync(request.BeginDate, request.EndDate, request.SensorId);

            if (readings == null)
            {
                readings = new ReadingsDto { SensorId = request.SensorId };
            }

            return readings;
        }
    }
}
