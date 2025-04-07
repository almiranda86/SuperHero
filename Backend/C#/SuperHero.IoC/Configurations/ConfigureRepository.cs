using Microsoft.Extensions.DependencyInjection;
using SuperHero.Domain.Behavior.Repository;
using SuperHero.ExternalService.Lookup;
using SuperHero.MongoDB.Lookup;
using SuperHero.MongoDB.Persister;
using SuperHero.Repository.Behavior;
using SuperHero.Repository.Lookup;
using SuperHero.Repository.Persister;

namespace SuperHero.IoC.Configurations;

public static class ConfigureRepository
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBaseHeroPersister, BaseHeroPersister>();
        services.AddScoped<IBaseHeroLookup, BaseHeroLookup>();
        services.AddScoped<ICompleteHeroLookup, CompleteHeroLookup>();
        services.AddScoped<ICompleteHeroPersister, CompleteHeroPersister>();
        services.AddScoped<IExternalApiLookup, ExternalApiLookup>();
        

        return services;
    }
}