using MediatR;
using sensor.Application.Readings.Commands;
using sensor.Domain.Models;
using System.Text.Json;

namespace sensor.Api.Messaging.Processing
{
    public class SensorMessageProcessor : ISensorMessageProcessor
    {
        private readonly IMediator _mediator;
        private readonly JsonSerializerOptions _serializerOptions;

        public SensorMessageProcessor(IMediator mediator)
        {
            _mediator = mediator;
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task ProcessMessage(string body, long unixTimeStamp)
        {
            var message = JsonSerializer.Deserialize<SensorMessage>(body, _serializerOptions);
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            var reading = new Reading { Metadata = new ReadingMetadata(message.SensorId, message.Type), Timestamp = dateTime, Value = message.Value };

            await _mediator.Send(new AddReadingCommand { Reading = reading });
        }
    }
}
