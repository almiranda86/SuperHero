using SuperHero.Domain.Model.CustomModel;

namespace SuperHero.Domain.Behavior.Repository
{
    public interface ICompleteHeroLookup
    {
        public Task<CompleteHero> GetCompleteHeroByPublicId(string publicId);
    }
}
