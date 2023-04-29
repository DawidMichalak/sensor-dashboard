using MediatR;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Commands
{
    public class AddDashboardConfigurationCommand : IRequest<DashboardConfiguration>
    {
    }
}
