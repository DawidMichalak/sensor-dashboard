using MediatR;
using SensorDashboard.Application.Configurations.Commands;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Handlers
{
    public class AddDashboardConfigurationCommandHandler : IRequestHandler<AddDashboardConfigurationCommand, DashboardConfiguration>
    {
        private readonly IConfigurationsRepository _repository;

        public AddDashboardConfigurationCommandHandler(IConfigurationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardConfiguration> Handle(AddDashboardConfigurationCommand request, CancellationToken cancellationToken)
        {
            var configuration = new DashboardConfiguration(Enumerable.Empty<ConfigurationItem>());

            return await _repository.AddAsync(configuration);
        }
    }
}
