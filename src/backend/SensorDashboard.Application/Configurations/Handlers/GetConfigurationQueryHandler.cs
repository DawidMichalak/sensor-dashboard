using MediatR;
using SensorDashboard.Application.Configurations.Queries;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Handlers
{
    public class GetConfigurationQueryHandler : IRequestHandler<GetConfigurationQuery, DashboardConfiguration>
    {
        private readonly IConfigurationsRepository _repository;

        public GetConfigurationQueryHandler(IConfigurationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardConfiguration> Handle(GetConfigurationQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
