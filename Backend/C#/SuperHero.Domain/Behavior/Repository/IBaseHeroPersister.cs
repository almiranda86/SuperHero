using SuperHero.Domain.Model;

namespace SuperHero.Repository.Behavior
{
    public interface IBaseHeroPersister
    {
        Task<bool> CreateBaseHero(IEnumerable<BaseHero> baseHeroCollection);
    }
}
