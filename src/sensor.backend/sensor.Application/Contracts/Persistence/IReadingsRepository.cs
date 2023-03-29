using sensor.Domain.Models;
using System.Linq.Expressions;

namespace sensor.Application.Contracts.Persistence
{
    public interface IReadingsRepository
    {
        Task AddReading(Reading reading);

        Task<IEnumerable<Reading>> GetReadings(Expression<Func<Reading, bool>> filter);
    }
}
