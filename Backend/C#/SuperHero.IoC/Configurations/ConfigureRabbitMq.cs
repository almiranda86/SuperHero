using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Infrastructure;
using SuperHero.Infrastructure.Settings;
using SuperHero.RabbitMq.Consumer;
using SuperHero.RabbitMq.Producer;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureRabbitMq
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<RabbitMqQueueSettings>().Bind(configuration.GetSection(SettingsSections.RabbitMQ));
            services.AddOptions<RabbitMqSettings>().Bind(configuration.GetSection(SettingsSections.RabbitMQ));
            services.AddScoped<ProducerContext>();
            services.AddScoped<ConsumerContext>();

            return services;
        }
    }
}
