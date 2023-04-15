using MediatR;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Application.Sensors.Queries;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Sensors.Handlers
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
