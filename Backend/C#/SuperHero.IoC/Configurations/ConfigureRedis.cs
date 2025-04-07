using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Infrastructure;
using SuperHero.Infrastructure.Settings;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureRedis
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var redisSettings = configuration.GetSection(SettingsSections.Redis).Get<RedisSettings>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisSettings.ConnectionString;
                options.InstanceName = redisSettings.InstanceName;
            });

            return services;
        }
    }
}
