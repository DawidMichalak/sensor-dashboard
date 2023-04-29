using MediatR;

namespace SensorDashboard.Application.Configurations.Commands
{
    public class UpdateConfigurationItemCommand : IRequest
    {
        public string DashboardId { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public int SensorId { get; set; }
    }
}
