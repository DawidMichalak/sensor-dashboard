using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace sensor.api.Messaging
{
    public class QueueConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly ILogger<QueueConsumer> _logger;
        private readonly IOptions<MessagingConfiguration> _configuration;

        public QueueConsumer(ILogger<QueueConsumer> logger, IOptions<MessagingConfiguration> configuration)
        {
            _configuration = configuration;
            _logger = logger;
            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = _configuration.Value.Host };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation(message);
            };

            _channel.BasicConsume(queue: _configuration.Value.QueueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
