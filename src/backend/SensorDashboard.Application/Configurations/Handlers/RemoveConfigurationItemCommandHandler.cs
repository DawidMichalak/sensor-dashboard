using MediatR;
using SensorDashboard.Application.Configurations.Commands;
using SensorDashboard.Application.Contracts.Persistence;

namespace SensorDashboard.Application.Configurations.Handlers
{
    public class RemoveConfigurationItemCommandHandler : IRequestHandler<RemoveConfigurationItemCommand>
    {
        private readonly IConfigurationsRepository _repository;

        public RemoveConfigurationItemCommandHandler(IConfigurationsRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveConfigurationItemCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveConfigurationItemAsync(request.DashboardId, request.ItemId);
        }
    }
}
