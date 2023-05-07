using MediatR;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Commands
{
    public class AddConfigurationItemCommand : IRequest<ConfigurationItem>
    {
        public string DashboardConfigurationId { get; set; }
        public string Name { get; set; }
        public int SensorId { get; set; }
    }
}
