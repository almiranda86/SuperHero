using SuperHero.RabbitMq.Consumer.Behavior;

namespace SuperHero.RabbitMq.Consumer.Strategy
{
    public class ConsumerResolver : IConsumerResolver
    {
        private IEnumerable<IPersisterConsumer> _consumers;

        public ConsumerResolver(IEnumerable<IPersisterConsumer> consumers)
        {
            _consumers = consumers;
        }

        public IPersisterConsumer ResolverConsumer(string queueName)
        {

            IPersisterConsumer persisterConsumer = _consumers.FirstOrDefault(c => c.QueueName.Equals(queueName));

            return persisterConsumer;
        }
    }
}
