namespace SuperHero.Security.Settings
{
    public class SecuritySettings
    {
        public TokenSettings TokenConfigurations { get; set; }
        public RolesSettings UserRoles { get; set; }
        public RootUserSettings RootAuthUsers { get; set; }
    }
}
