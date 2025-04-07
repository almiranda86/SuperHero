namespace SuperHero.Infrastructure
{
    public struct SettingsSections
    {
        public const string Redis = nameof(Redis);
        public const string MongoDB = nameof(MongoDB);
        public const string HeroAPI = nameof(HeroAPI);
        public const string RabbitMQ = nameof(RabbitMQ);
        public const string TokenConfigurations = "Security:TokenConfigurations";
        public const string TokenRoles = "Security:UserRoles:Roles";
        public const string RootUsers = "Security:RootAuthUsers";
        public const string Security = nameof(Security);
    }
}
