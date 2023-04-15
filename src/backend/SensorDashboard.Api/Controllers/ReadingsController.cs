using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorDashboard.Api.Requests;
using SensorDashboard.Application.Readings.Commands;
using SensorDashboard.Application.Readings.Queries;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Api.Controllers
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
            var query = new GetReadingsQuery { BeginDate = request.BeginDate, EndDate = request.EndDate };
            var readings = await _mediator.Send(query);
            return Ok(readings);
        }

        [HttpGet("{sensorId}")]
        public async Task<IActionResult> GetSensorReadings([FromQuery] GetReadingRequest request, [FromRoute] int sensorId)
        {
            var query = new GetSensorReadingsQuery { BeginDate = request.BeginDate, EndDate = request.EndDate, SensorId = sensorId };
            var readings = await _mediator.Send(query);
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
