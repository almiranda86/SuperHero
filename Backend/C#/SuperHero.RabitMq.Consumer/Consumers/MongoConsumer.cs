using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.Infrastructure.Settings;
using SuperHero.RabbitMq.Consumer.Behavior;
using SuperHero.RabbitMq.Consumer.Helper;

namespace SuperHero.RabbitMq.Consumer.Consumers
{
    public class MongoConsumer : IPersisterConsumer
    {
        private readonly IOptions<RabbitMqQueueSettings> _queueSettings;
        private readonly ConsumerContext _consumerContext;
        private readonly ICompleteHeroPersister _completeHeroPersister;

        public string QueueName { get; set; }
        public MongoConsumer(ConsumerContext consumerContext, ICompleteHeroPersister completeHeroPersister, IOptions<RabbitMqQueueSettings> queueSettings)
        {
            _consumerContext = consumerContext;
            _completeHeroPersister = completeHeroPersister;
            _queueSettings = queueSettings;

            QueueName = _queueSettings.Value.Queues[0];
        }

        public async Task ConsumeMessage()
        {
            _consumerContext.RabbitMqChanel.QueueDeclare(QueueName, false, false, false, null);

            BasicGetResult result = _consumerContext.RabbitMqChanel.BasicGet(QueueName, true);

            if (result != null)
            {
                var message = ConsumeMessageHelper.OpenMessage(result.Body);

                var completeHero = JsonConvert.DeserializeObject<CompleteHero>(message);

                await _completeHeroPersister.CreateCompleteHero(completeHero);
            }
        }
    }
}
