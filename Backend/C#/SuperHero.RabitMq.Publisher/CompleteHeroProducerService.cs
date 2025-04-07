using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SuperHero.Domain.Behavior.Event;
using SuperHero.Infrastructure.Settings;
using System.Text;

namespace SuperHero.RabbitMq.Producer
{
    public class CompleteHeroProducerService : ICompleteHeroProducer
    {
        private readonly ProducerContext _producerContext;
        private readonly IOptions<RabbitMqQueueSettings> _queueSettings;

        public CompleteHeroProducerService(ProducerContext producerContext, IOptions<RabbitMqQueueSettings> queueSettings)
        {
            _producerContext = producerContext;
            _queueSettings = queueSettings;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var bodyAsByteArray = Encoding.UTF8.GetBytes(json);

            var queues = _queueSettings.Value.Queues;

            foreach (var queue in queues)
            {
                PostToQueue(queue, bodyAsByteArray);
            }
        }

        public void SendMessage<T>(T message, string queueName)
        {
            var json = JsonConvert.SerializeObject(message);
            var bodyAsByteArray = Encoding.UTF8.GetBytes(json);

            PostToQueue(queueName, bodyAsByteArray);
        }

        private void PostToQueue(string queue, byte[]? bodyAsByteArray)
        {
            _producerContext.RabbitMqChanel.QueueDeclare(queue, false, false, false, null);
            _producerContext.RabbitMqChanel.BasicPublish(exchange: string.Empty, routingKey: queue, body: bodyAsByteArray);
        }
    }
}
