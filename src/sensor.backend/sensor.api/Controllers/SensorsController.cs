using MediatR;
using Microsoft.AspNetCore.Mvc;
using sensor.Application.Sensors.Commands;
using sensor.Application.Sensors.Queries;

namespace sensor.Api.Controllers
{
    [ApiController]
    [Route("sensors")]
    public class SensorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SensorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSensors()
        {
            var query = new GetSensorsQuery();
            var sensors = await _mediator.Send(query);
            return Ok(sensors);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSensor([FromBody] AddSensorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
