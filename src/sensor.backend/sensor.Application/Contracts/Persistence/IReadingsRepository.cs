using sensor.Domain.Models;
using System.Linq.Expressions;

namespace sensor.Application.Contracts.Persistence
{
    public interface IReadingsRepository
    {
        Task AddReadingAsync(Reading reading);

        Task<IEnumerable<ReadingsDto>> GetReadingsAsync(DateTime beginDate, DateTime endDate);
    }
}
