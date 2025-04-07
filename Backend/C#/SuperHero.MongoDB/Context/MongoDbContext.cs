using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.MongoDB.Settings;

namespace SuperHero.MongoDB.Context
{
    public class MongoDbContext
    {
        private readonly IMongoCollection<CompleteHero> _completeHeroCollection;
        public MongoDbContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _completeHeroCollection = database.GetCollection<CompleteHero>(mongoDBSettings.Value.CollectionName);
        }

        public IMongoCollection<CompleteHero> CompleteHero
        {
            get
            {
                return _completeHeroCollection;
            }
        }
    }
}
