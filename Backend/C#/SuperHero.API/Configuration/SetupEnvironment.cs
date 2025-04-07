using SuperHero.Domain.Behavior;

namespace SuperHero.API.Configuration
{
    public static class SetupEnvironment
    {
        public static void DoSetup(this IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                var dbService = scope.ServiceProvider.GetService<IInitializeDbService>();
                dbService?.InitializeDb();

                var securityService = scope.ServiceProvider.GetService<IInitializeSecurityService>();
                securityService?.InitializeSecurity();
            };
        }
    }
}
