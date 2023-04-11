using MediatR;
using sensor.Domain.Models;

namespace sensor.Application.Readings.Commands
{
    public class AddReadingCommand : IRequest
    {
        public Reading Reading { get; init; }
    }
}
