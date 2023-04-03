using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using sensor.api.Messaging.Processing;
using System.Text;

namespace sensor.api.Messaging
{
    public class QueueConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly ILogger<QueueConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly MessagingConfiguration _configuration;

        public QueueConsumer(ILogger<QueueConsumer> logger, IOptions<MessagingConfiguration> configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration.Value;
            _logger = logger;
            _serviceProvider = serviceProvider;
            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = _configuration.Host };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (ModuleHandle, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var timestamp = ea.BasicProperties.Timestamp.UnixTime;
                _logger.LogInformation(message);

                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    var messageProcessor = scope.ServiceProvider.GetRequiredService<ISensorMessageProcessor>();
                    await messageProcessor.ProcessMessage(message, timestamp);
                }
            };

            _channel.BasicConsume(queue: _configuration.QueueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
