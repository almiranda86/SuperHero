using SuperHero.Security.Domain.Model;

namespace SuperHero.Security.Settings
{
    public class RootUserSettings
    {
        public List<UserSettings> AuthUsers { get; set; }

        public RootUserSettings()
        {

        }

        public RootUserSettings(List<UserSettings> authUsers)
        {
            AuthUsers = authUsers;
        }
    }
}
