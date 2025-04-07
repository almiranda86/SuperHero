using SuperHero.Domain.Behavior.Repository;
using SuperHero.Domain.Model;
using SuperHero.Repository.Context;

namespace SuperHero.Repository.Lookup
{
    public class BaseHeroLookup : IBaseHeroLookup
    {
        private readonly HeroContext _heroContext;

        public BaseHeroLookup(HeroContext heroContext)
        {
            _heroContext = heroContext;
        }

        public async Task<BaseHero> GetBaseHeroByPublicId(string publicId)
        {
            var hero = await _heroContext.BaseHero.FindAsync(publicId);

            return hero;
        }

        public async Task<(IEnumerable<BaseHero>, int TotalPages)> ListAllHeroesPaginated(int page, int pageSize, CancellationToken cancellationToken)
        {
            var allHeroes = _heroContext.BaseHero.ToList();
            var paginatedHeroes = allHeroes.Skip((page - 1) * pageSize).Take(pageSize);
            var totalPages = allHeroes.Count / pageSize;


            return (paginatedHeroes, totalPages);
        }
    }
}
