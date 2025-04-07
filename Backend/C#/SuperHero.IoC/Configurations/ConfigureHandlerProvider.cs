using Microsoft.Extensions.DependencyInjection;
using SuperHero.Core.MediatR;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureHandlerProvider
    {
        public static void SetHanlerProvider(this IServiceProvider provider)
        {
            ServiceLocator.SetLocatorProvider(provider.CreateScope().ServiceProvider);
        }
    }
}
