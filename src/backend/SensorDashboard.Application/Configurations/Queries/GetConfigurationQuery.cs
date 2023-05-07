using MediatR;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Configurations.Queries
{
    public class GetConfigurationQuery : IRequest<DashboardConfiguration>
    {
        public string Id { get; set; }
    }
}
