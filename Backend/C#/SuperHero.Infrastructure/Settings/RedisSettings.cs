namespace SuperHero.Infrastructure.Settings
{
    public class RedisSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string ExpireInMinutes { get; set; } = null!;
        public string InstanceName { get; set; } = null!;
        public string ConnectionStringName { get; set; } = null!;
    }
}
