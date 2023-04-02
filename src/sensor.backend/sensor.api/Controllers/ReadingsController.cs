using Microsoft.AspNetCore.Mvc;
using sensor.Application.Contracts.Persistence;
using sensor.Domain.Models;

namespace sensor.api.Controllers
{
    [ApiController]
    [Route("readings")]
    public class ReadingsController : ControllerBase
    {
        private readonly IReadingsRepository _readingsRepository;

        public ReadingsController(IReadingsRepository readingsRepository)
        {
            _readingsRepository = readingsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetReadings()
        {
            var readings = await _readingsRepository.GetReadings();
            return Ok(readings);
        }

        [HttpPost]
        public async Task<IActionResult> AddReading([FromBody] Reading reading)
        {
            await _readingsRepository.AddReading(reading);
            return Ok();
        }
    }
}
