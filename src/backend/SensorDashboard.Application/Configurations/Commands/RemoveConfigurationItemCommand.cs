using MediatR;

namespace SensorDashboard.Application.Configurations.Commands
{
    public class RemoveConfigurationItemCommand : IRequest
    {
        public string DashboardId { get; set; }
        public string ItemId { get; set; }
    }
}
