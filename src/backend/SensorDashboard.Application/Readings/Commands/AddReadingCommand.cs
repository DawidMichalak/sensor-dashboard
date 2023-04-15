using MediatR;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Application.Readings.Commands
{
    public class AddReadingCommand : IRequest
    {
        public Reading Reading { get; init; }
    }
}
