using MediatR;
using Microsoft.AspNetCore.Mvc;
using sensor.Api.Requests;
using sensor.Application.Readings.Commands;
using sensor.Application.Readings.Queries;
using sensor.Domain.Models;

namespace sensor.Api.Controllers
{
    [ApiController]
    [Route("readings")]
    public class ReadingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReadingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReadings([FromQuery] GetReadingRequest request)
        {
            var readings = await _mediator.Send(new GetReadingsQuery { BeginDate = request.BeginDate, EndDate = request.EndDate });
            return Ok(readings);
        }

        [HttpPost]
        public async Task<IActionResult> AddReading([FromBody] Reading reading)
        {
            var command = new AddReadingCommand() { Reading = reading };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
