using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorDashboard.Api.Requests;
using SensorDashboard.Application.Configurations.Commands;
using SensorDashboard.Application.Configurations.Queries;
using SensorDashboard.Domain.Models;

namespace SensorDashboard.Api.Controllers
{
    [ApiController]
    [Route("configurations")]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConfigurationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{configurationId}")]
        public async Task<ActionResult<DashboardConfiguration>> GetConfiguration([FromRoute] string configurationId)
        {
            var configuration = await _mediator.Send(new GetConfigurationQuery() { Id = configurationId });

            return Ok(configuration);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfiguration()
        {
            var configuration = await _mediator.Send(new AddDashboardConfigurationCommand());
            return Created($"configuration/{configuration.Id}", configuration);
        }

        [HttpPost("{configurationId}")]
        public async Task<IActionResult> AddConfigurationItem([FromRoute] string configurationId, [FromBody] AddConfigurationItemRequest request)
        {
            var command = new AddConfigurationItemCommand()
            {
                DashboardConfigurationId = configurationId,
                Name = request.Name,
                SensorId = request.SensorId
            };
            var createdItem = await _mediator.Send(command);
            return Created($"configuration/{configurationId}/item/{createdItem.Id}", createdItem);
        }

        [HttpPatch("{configurationId}/item/{itemId}")]
        public async Task<IActionResult> UpdateConfigurationItem([FromRoute] string configurationId, [FromRoute] string itemId, [FromQuery] UpdateConfigurationItemRequest item)
        {
            var command = new UpdateConfigurationItemCommand() { DashboardId = configurationId, ItemId = itemId, Name = item.Name, SensorId = item.SensorId };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{configurationId}/item/{itemId}")]
        public async Task<IActionResult> RemoveConfigurationItem([FromRoute] string configurationId, [FromRoute] string itemId)
        {
            var command = new RemoveConfigurationItemCommand() { DashboardId = configurationId, ItemId = itemId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
