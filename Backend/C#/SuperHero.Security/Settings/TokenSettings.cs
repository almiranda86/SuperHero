namespace SuperHero.Security.Settings
{
    public class TokenSettings
    {
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public int Seconds { get; set; }
        public string? SecretJwtKey { get; set; }
    }
}
