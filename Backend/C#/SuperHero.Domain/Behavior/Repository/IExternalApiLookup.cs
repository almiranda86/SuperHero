using SuperHero.Domain.Model.CustomModel;

namespace SuperHero.Domain.Behavior.Repository
{
    public interface IExternalApiLookup
    {
        Task<CompleteHero> GetCompleteHeroById(int heroId);
    }
}
