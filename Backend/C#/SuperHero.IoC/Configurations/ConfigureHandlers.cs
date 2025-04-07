using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Service.Handlers;
using System.Reflection;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureHandlers
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(ListAllHeroesPaginatedRequestHandler));
            services.AddMediatR(typeof(GetHeroeByPublicIdRequestHandler));
            services.AddMediatR(typeof(LoginUserRequestHandler));
            return services;
        }
    }
}
