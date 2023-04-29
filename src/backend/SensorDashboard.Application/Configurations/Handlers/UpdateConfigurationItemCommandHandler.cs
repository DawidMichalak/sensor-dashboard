using MediatR;
using SensorDashboard.Application.Configurations.Commands;
using SensorDashboard.Application.Contracts.Persistence;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Handlers
{
    public class UpdateConfigurationItemCommandHandler : IRequestHandler<UpdateConfigurationItemCommand>
    {
        private readonly IConfigurationsRepository _repository;

        public UpdateConfigurationItemCommandHandler(IConfigurationsRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateConfigurationItemCommand request, CancellationToken cancellationToken)
        {
            var newItem = new ConfigurationItem(request.Name, request.SensorId)
            {
                Id = request.ItemId
            };

            await _repository.UpdateConfigurationItemAsync(request.DashboardId, newItem);
        }
    }
}
