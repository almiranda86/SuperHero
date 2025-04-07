using SuperHero.Domain.Model;
using SuperHero.Repository.Behavior;
using SuperHero.Repository.Context;

namespace SuperHero.Repository.Persister
{
    public class BaseHeroPersister : IBaseHeroPersister
    {
        private readonly HeroContext _context;

        public BaseHeroPersister(HeroContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateBaseHero(IEnumerable<BaseHero> baseHeroCollection)
        {
            await _context.AddRangeAsync(baseHeroCollection);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
