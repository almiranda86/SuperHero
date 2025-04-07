namespace SuperHero.Domain.Behavior.Event
{
    public interface ICompleteHeroProducer : IDisposable
    {
        public void SendMessage<T>(T message);
        public void SendMessage<T>(T message, string queueName);
    }
}
