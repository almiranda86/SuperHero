using Microsoft.Extensions.DependencyInjection;
using SuperHero.Infrastructure.Extensions;
using SuperHero.RabbitMq.Consumer.Behavior;
using SuperHero.RabbitMq.Consumer.Strategy;
using System.Reflection;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureRabbitConsumerStrategy
    {
        public static IServiceCollection AddRabbitConsumerStrategyResolver(this IServiceCollection services)
        {
            Assembly.GetEntryAssembly().GetTypeAssignableFrom<IPersisterConsumer>().ForEach((assignableType) =>
            {
                services.AddScoped(typeof(IPersisterConsumer), assignableType);
            });

            return services;
        }

        public static IServiceCollection AddRabbitConsumerResolver(this IServiceCollection services)
        {
            services.AddScoped<IConsumerResolver, ConsumerResolver>();

            return services;
        }
    }
}
