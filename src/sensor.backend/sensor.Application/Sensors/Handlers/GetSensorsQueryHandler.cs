using MediatR;
using sensor.Application.Contracts.Persistence;
using sensor.Application.Sensors.Queries;
using sensor.Domain.Models;

namespace sensor.Application.Sensors.Handlers
{
    internal sealed class GetSensorsQueryHandler : IRequestHandler<GetSensorsQuery, IEnumerable<Sensor>>
    {
        private readonly ISensorsRepository _repository;

        public GetSensorsQueryHandler(ISensorsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Sensor>> Handle(GetSensorsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSensorsAsync();
        }
    }
}
