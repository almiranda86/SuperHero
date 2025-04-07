namespace SuperHero.Domain.Behavior.Event
{
    public interface ICompleteHeroConsumer
    {
        Task ConsumeMessage();
    }
}
