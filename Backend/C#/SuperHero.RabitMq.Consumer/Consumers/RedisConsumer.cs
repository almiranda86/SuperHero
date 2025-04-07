using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.Infrastructure.Settings;
using SuperHero.RabbitMq.Consumer.Behavior;
using SuperHero.RabbitMq.Consumer.Helper;
using SuperHero.Redis.Extension;

namespace SuperHero.RabbitMq.Consumer.Consumers
{
    public class RedisConsumer : IPersisterConsumer
    {
        private readonly IOptions<RabbitMqQueueSettings> _queueSettings;
        private readonly ConsumerContext _consumerContext;
        private readonly IDistributedCache _redisCache;

        public string QueueName { get; set; }
        public RedisConsumer(ConsumerContext consumerContext, IDistributedCache redisCache, IOptions<RabbitMqQueueSettings> queueSettings)
        {
            _consumerContext = consumerContext;
            _redisCache = redisCache;
            _queueSettings = queueSettings;
            QueueName = _queueSettings.Value.Queues[1];
        }

        public async Task ConsumeMessage()
        {
            _consumerContext.RabbitMqChanel.QueueDeclare(QueueName, false, false, false, null);

            BasicGetResult result = _consumerContext.RabbitMqChanel.BasicGet(QueueName, true);

            if (result != null)
            {
                var message = ConsumeMessageHelper.OpenMessage(result.Body);

                var completeHero = JsonConvert.DeserializeObject<CompleteHero>(message);

                if(completeHero != null) {
                    await _redisCache.PostRecordAsync(completeHero.PublicId, completeHero);
                }                
            }
        }
    }
}
