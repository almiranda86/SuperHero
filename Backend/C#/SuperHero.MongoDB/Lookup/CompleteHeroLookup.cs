using MongoDB.Driver;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.MongoDB.Context;

namespace SuperHero.MongoDB.Lookup
{
    public class CompleteHeroLookup : ICompleteHeroLookup
    {
        private readonly MongoDbContext _mongoContext;
        public CompleteHeroLookup(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<CompleteHero> GetCompleteHeroByPublicId(string publicId)
        {
            var response = await _mongoContext.CompleteHero.Find(ch => ch.PublicId.Equals(publicId)).FirstOrDefaultAsync();

            return response;
        }
    }
}
