using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Repository.Context;
using SuperHero.Security.Context;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<HeroContext>(x => x.UseInMemoryDatabase("InMemoryDb"));
            services.AddDbContext<SecurityDbContext>(x => x.UseInMemoryDatabase("InMemoryDb"));

            return services;
        }
    }
}
