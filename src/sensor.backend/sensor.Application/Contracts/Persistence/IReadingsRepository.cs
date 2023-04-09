using sensor.Domain.Models;
using System.Linq.Expressions;

namespace sensor.Application.Contracts.Persistence
{
    public interface IReadingsRepository
    {
        Task AddReadingAsync(Reading reading);

        Task<IEnumerable<ReadingsDto>> GetAllReadingsAsync(DateTime beginDate, DateTime endDate);

        Task<ReadingsDto> GetReadingsAsync(DateTime beginDate, DateTime endDate, int sensorId);
    }
}
