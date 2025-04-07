using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureCors
    {
        private readonly static string policyName = "localhostPolicy";

        public static IServiceCollection AddCorsForLocalhost(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                                  builder =>
                                  {
                                      builder 
                                        .AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                                  });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsForLocalhost(this IApplicationBuilder builder)
        {
            builder.UseCors(policyName);

            return builder;
        }
    }
}
