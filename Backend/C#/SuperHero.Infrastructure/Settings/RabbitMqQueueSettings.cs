namespace SuperHero.Infrastructure.Settings
{
    public class RabbitMqQueueSettings
    {
        public string[] Queues { get; set; }
        public int ConsumeDelayInMilliseconds { get; set; } = 0!;
    }
}
