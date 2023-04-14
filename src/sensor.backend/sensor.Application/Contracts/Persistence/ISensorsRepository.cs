using sensor.Domain.Models;
using System.Linq.Expressions;

namespace sensor.Application.Contracts.Persistence
{
    public interface ISensorsRepository
    {
        Task AddSensorAsync(Sensor sensor);

        Task DeleteAsync(int sensorId);

        Task<IEnumerable<Sensor>> GetSensorsAsync();

        Task<IEnumerable<Sensor>> GetSensorsWhereAsync(Expression<Func<Sensor, bool>> filter);

        Task UpdateAsync(Sensor sensor);
    }
}
