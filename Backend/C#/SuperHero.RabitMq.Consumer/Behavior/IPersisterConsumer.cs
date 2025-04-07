namespace SuperHero.RabbitMq.Consumer.Behavior
{
    public interface IPersisterConsumer
    {
        public string QueueName { get; set; }

        public Task ConsumeMessage();
    }
}
