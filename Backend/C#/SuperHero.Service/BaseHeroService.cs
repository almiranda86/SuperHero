using SuperHero.Domain.Behavior.Service;
using SuperHero.Repository.Behavior;

namespace SuperHero.Service
{
    public class BaseHeroService : IBaseHeroService
    {
        private readonly IBaseHeroPersister _baseHeroPersister;
        public BaseHeroService(IBaseHeroPersister baseHeroPersister)
        {
            _baseHeroPersister = baseHeroPersister;
        }

        public async Task CreateBaseHero(IEnumerable<Domain.Model.BaseHero> baseHeroCollection)
        {
            _ = await _baseHeroPersister.CreateBaseHero(baseHeroCollection);
        }
    }
}
