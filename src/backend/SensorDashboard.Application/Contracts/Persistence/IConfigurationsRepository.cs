using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Contracts.Persistence
{
    public interface IConfigurationsRepository
    {
        Task<DashboardConfiguration> AddAsync(DashboardConfiguration configuration);

        Task<ConfigurationItem> AddConfigurationItemAsync(string dashboardId, ConfigurationItem item);

        Task<DashboardConfiguration> GetAsync(string id);

        Task RemoveConfigurationItemAsync(string dashboardId, string ItemId);

        Task UpdateConfigurationItemAsync(string dashboardId, ConfigurationItem item);
    }
}
