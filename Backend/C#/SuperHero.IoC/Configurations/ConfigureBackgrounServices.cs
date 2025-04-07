using Microsoft.Extensions.DependencyInjection;
using SuperHero.Domain.Behavior.Event;
using SuperHero.RabbitMq.Consumer;

namespace SuperHero.IoC.Configurations;

public static class ConfigureBackgrounServices
{
    public static IServiceCollection AddBackroundServices(this IServiceCollection services)
    {
        services.AddScoped<ICompleteHeroConsumer, CompleteHeroConsumer>();
        services.AddSingleton<ConsumerBackgroundService>();
        services.AddHostedService<ConsumerBackgroundService>();

        return services;
    }
}