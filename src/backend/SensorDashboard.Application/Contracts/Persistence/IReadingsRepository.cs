using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Contracts.Persistence
{
    public interface IReadingsRepository
    {
        Task AddReadingAsync(Reading reading);

        Task<IEnumerable<ReadingsDto>> GetAllReadingsAsync(DateTime beginDate, DateTime endDate);

        Task<ReadingsDto> GetReadingsAsync(DateTime beginDate, DateTime endDate, int sensorId);
    }
}
