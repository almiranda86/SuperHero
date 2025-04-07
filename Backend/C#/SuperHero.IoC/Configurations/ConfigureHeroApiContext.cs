using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.ExternalService.Settings;
using SuperHero.Infrastructure;
using SuperHero.MongoDB.Context;
using SuperHero.MongoDB.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureHeroApiContext
    {
        public static IServiceCollection AddHeroAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<HeroApiSettings>().Bind(configuration.GetSection(SettingsSections.HeroAPI));

            return services;
        }
    }
}
