using SuperHero.RabbitMq.Consumer.Behavior;

namespace SuperHero.RabbitMq.Consumer.Strategy
{
    public interface IConsumerResolver
    {
        public IPersisterConsumer ResolverConsumer(string queueName);
    }
}
