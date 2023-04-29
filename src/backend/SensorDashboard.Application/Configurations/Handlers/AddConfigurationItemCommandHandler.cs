using MediatR;
using SensorDashboard.Application.Configurations.Commands;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Handlers
{
    public class AddConfigurationItemCommandHandler : IRequestHandler<AddConfigurationItemCommand, ConfigurationItem>
    {
        private readonly IConfigurationsRepository _repository;

        public AddConfigurationItemCommandHandler(IConfigurationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConfigurationItem> Handle(AddConfigurationItemCommand request, CancellationToken cancellationToken)
        {
            var configurationItem = new ConfigurationItem(request.Name, request.SensorId);
            return await _repository.AddConfigurationItemAsync(request.DashboardConfigurationId, configurationItem);
        }
    }
}
