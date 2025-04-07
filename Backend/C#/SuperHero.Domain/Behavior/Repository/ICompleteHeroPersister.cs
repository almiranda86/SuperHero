using SuperHero.Domain.Model.CustomModel;

namespace SuperHero.Domain.Behavior.Repository
{
    public interface ICompleteHeroPersister
    {
        Task<bool> CreateCompleteHero(CompleteHero completeHero);
    }
}
