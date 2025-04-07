using Microsoft.EntityFrameworkCore;
using SuperHero.Domain.Model;
using SuperHero.Repository.Context.Base;

namespace SuperHero.Repository.Context
{
    public class HeroContext : InMemoryDB<HeroContext>
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options)
        {
        }

        public DbSet<BaseHero> BaseHero { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BaseHero>(x => { x.HasKey(y => y.PublicId); });
        }
    }
}
