using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorDashboard.Application.Sensors.Commands;
using SensorDashboard.Application.Sensors.Queries;

namespace SensorDashboard.Api.Controllers
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

        [HttpPatch]
        public async Task<IActionResult> UpdateSensor([FromBody] UpdateSensorCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{sensorId}")]
        public async Task<IActionResult> DeleteSensor([FromRoute] int sensorId)
        {
            var command = new DeleteSensorCommand() { Id = sensorId };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
