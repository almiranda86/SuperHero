using Microsoft.Extensions.Options;
using SuperHero.Domain.Behavior.Event;
using SuperHero.Infrastructure.Settings;
using SuperHero.RabbitMq.Consumer.Behavior;
using SuperHero.RabbitMq.Consumer.Strategy;

namespace SuperHero.RabbitMq.Consumer
{
    public class CompleteHeroConsumer : ICompleteHeroConsumer
    {
        private readonly IOptions<RabbitMqQueueSettings> _queueSettings;
        private readonly IConsumerResolver _consumerResolver;

        public CompleteHeroConsumer(IConsumerResolver consumerResolver,
                                    IOptions<RabbitMqQueueSettings> queueSettings)
        {
            _queueSettings = queueSettings;
            _consumerResolver = consumerResolver;
        }

        public async Task ConsumeMessage()
        {
            var queues = _queueSettings.Value.Queues;

            foreach (var queue in queues)
            {
                IPersisterConsumer persisterConsumer = _consumerResolver.ResolverConsumer(queue);

                await persisterConsumer.ConsumeMessage();
            }
        }
    }
}
