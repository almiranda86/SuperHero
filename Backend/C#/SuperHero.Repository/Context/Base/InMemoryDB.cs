using Microsoft.EntityFrameworkCore;

namespace SuperHero.Repository.Context.Base
{
    public class InMemoryDB<TModel> : DbContext where TModel : DbContext
    {
        public InMemoryDB(DbContextOptions<TModel> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
