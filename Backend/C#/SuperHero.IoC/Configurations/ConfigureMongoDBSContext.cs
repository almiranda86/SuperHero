using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Infrastructure;
using SuperHero.MongoDB.Context;
using SuperHero.MongoDB.Settings;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureMongoDBSContext
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<MongoDBSettings>().Bind(configuration.GetSection(SettingsSections.MongoDB));
            services.AddScoped<MongoDbContext>();

            return services;
        }
    }
}
