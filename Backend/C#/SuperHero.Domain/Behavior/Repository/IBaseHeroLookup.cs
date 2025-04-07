using SuperHero.Domain.Model;

namespace SuperHero.Domain.Behavior.Repository
{
    public interface IBaseHeroLookup
    {
        Task<(IEnumerable<BaseHero>, int TotalPages)> ListAllHeroesPaginated(int page, int pageSize, CancellationToken cancellationToken);

        Task<BaseHero> GetBaseHeroByPublicId(string publicId);
    }
}
