using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Infrastructure.Middleware;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureGlobalExceptionMiddleware
    {
        public static IServiceCollection AddGlobalExceptionMiddleware(this IServiceCollection services)
        {
            services.AddScoped<GlobalExceptionMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionMiddleware>();

            return builder;
        }
    }
}
