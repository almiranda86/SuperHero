using Microsoft.Extensions.DependencyInjection;
using SuperHero.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SuperHero.Security.Settings;
using SuperHero.Security.Domain.Model;
using SuperHero.Security.Domain.Behavior;
using SuperHero.Security.Service;
using SuperHero.Security.Context;
using SuperHero.MongoDB.Settings;
using Microsoft.Extensions.Options;

namespace SuperHero.IoC.Configurations
{
    public static class ConfigureSecurity
    {
        public static IServiceCollection AddBearerDefinition(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfigurations = configuration.GetSection(SettingsSections.TokenConfigurations);
            services.AddOptions<TokenSettings>().Bind(tokenConfigurations);
            services.AddOptions<SecuritySettings>().Bind(configuration.GetSection(SettingsSections.Security));
            services.AddJwtSecurity(tokenConfigurations.Get<TokenSettings>());

            return services;
        }

        private static IServiceCollection AddJwtSecurity(this IServiceCollection services, TokenSettings? tokenSettingsOptions)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<SecurityDbContext>();

            var signingConfigurations = new SigningConfigurations(tokenSettingsOptions?.SecretJwtKey!);
            services.AddSingleton<ISigningConfigurations>(signingConfigurations);

            services.AddSingleton(tokenSettingsOptions);

            services.AddScoped<IAccessManagerService, AccessManagerService>();

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenSettingsOptions?.Audience;
                paramsValidation.ValidIssuer = tokenSettingsOptions?.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }
    }
}
