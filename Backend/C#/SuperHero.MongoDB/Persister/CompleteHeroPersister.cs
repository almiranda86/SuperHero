using MongoDB.Driver;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.Domain.Model.CustomModel;
using SuperHero.MongoDB.Context;

namespace SuperHero.MongoDB.Persister
{
    public class CompleteHeroPersister : ICompleteHeroPersister
    {
        private readonly MongoDbContext _mongoContext;

        public CompleteHeroPersister(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<bool> CreateCompleteHero(CompleteHero completeHero)
        {
            //INSERT or UPDATE
            try
            {
                UpdateOptions updateOptions = new() { IsUpsert = true };
                var filter = DefineFilterCondition(completeHero);
                var updateDefinition = DefineUpdateObject(completeHero);

                await _mongoContext.CompleteHero.UpdateOneAsync(filter, updateDefinition, options: updateOptions);
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        private FilterDefinition<CompleteHero> DefineFilterCondition(CompleteHero completeHero)
        {
            var filter = Builders<CompleteHero>.Filter.Eq(ch => ch.PublicId, completeHero.PublicId);
            return filter;
        }

        private UpdateDefinition<CompleteHero> DefineUpdateObject(CompleteHero completeHero)
        {
            var updateBuilder = new UpdateDefinitionBuilder<CompleteHero>();

            var updateDefinition = updateBuilder.SetOnInsert(ch => ch.Powerstats, completeHero.Powerstats)
                                                .SetOnInsert(ch => ch.Biography, completeHero.Biography)
                                                .SetOnInsert(ch => ch.Appearance, completeHero.Appearance)
                                                .SetOnInsert(ch => ch.Work, completeHero.Work)
                                                .SetOnInsert(ch => ch.Connections, completeHero.Connections)
                                                .SetOnInsert(ch => ch.Image, completeHero.Image)
                                                .SetOnInsert(ch => ch.Name, completeHero.Name)
                                                .SetOnInsert(ch => ch.PublicId, completeHero.PublicId);

            return updateDefinition;
        }
    }
}
