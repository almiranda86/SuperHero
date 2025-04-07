using Microsoft.Extensions.DependencyInjection;
using SuperHero.Domain.Behavior;
using SuperHero.Domain.Behavior.Event;
using SuperHero.Domain.Behavior.Service;
using SuperHero.ExternalService;
using SuperHero.ExternalService.Behavior;
using SuperHero.RabbitMq.Consumer;
using SuperHero.RabbitMq.Producer;
using SuperHero.Security.Domain.Behavior;
using SuperHero.Security.Service;
using SuperHero.Service;

namespace SuperHero.IoC.Configurations;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISetupSecurityService, SetupSecurityService>();
        services.AddScoped<IInitializeDbService, Setup>();
        services.AddScoped<IInitializeSecurityService, Setup>(); 
        services.AddScoped<IBaseHeroService, BaseHeroService>();
        services.AddScoped<ICompleteHeroProducer, CompleteHeroProducerService>();
        services.AddTransient<IRestService, RestService>();
        

        return services;
    }
}