using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SuperHero.Infrastructure.Settings;

namespace SuperHero.RabbitMq.Producer
{
    public class ProducerContext
    {
        private readonly IModel _chanel;

        public ProducerContext(IOptions<RabbitMqSettings> rabbitMqSettings)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(rabbitMqSettings.Value.ConnectionURI)
            };

            var connection = factory.CreateConnection();

            _chanel = connection.CreateModel();
        }

        public IModel RabbitMqChanel
        {
            get
            {
                return _chanel;
            }
        }
    }
}
