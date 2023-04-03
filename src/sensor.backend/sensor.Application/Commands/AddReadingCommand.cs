using MediatR;
using sensor.Domain.Models;

namespace sensor.Application.Commands
{
    public class AddReadingCommand : IRequest
    {
        public Reading Reading { get; init; }
    }
}
