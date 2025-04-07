namespace SuperHero.Security.Settings
{
    public class RolesSettings
    {
        public List<string> Roles { get; set; }

        public RolesSettings()
        {

        }

        public RolesSettings(List<string> roles)
        {
            Roles = roles;  
        }
    }
}
