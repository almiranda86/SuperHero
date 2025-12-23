using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SuperHero.Security.Domain.Behavior;
using SuperHero.Security.Domain.Model;
using SuperHero.Security.Settings;

namespace SuperHero.Service
{
    public class SetupSecurityService : ISetupSecurityService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RolesSettings _rolesSettings;
        private readonly RootUserSettings _rootUserSettings;

        private readonly IOptions<SecuritySettings> _security;

        public SetupSecurityService(RoleManager<IdentityRole> roleManager,
                                    UserManager<ApplicationUser> userManager,
                                    IOptions<SecuritySettings> security)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _security = security;
            _rolesSettings = new RolesSettings(_security.Value.UserRoles.Roles);
            _rootUserSettings = new RootUserSettings(_security.Value.RootAuthUsers.AuthUsers);
            
        }

        public async Task CreateRoles()
        {
            var roles = _rolesSettings.Roles;

            foreach (var role in roles)
            {
                await AddToRoleManager(role);
            }
        }

        private async Task AddToRoleManager(string role)
        {
            if (!_roleManager.RoleExistsAsync(role).Result)
            {
                var resultado = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!resultado.Succeeded)
                {
                    throw new Exception($"Error during role creation: {role}.");
                }
            }
        }



        public async Task CreateRootUser()
        {
            var users = _rootUserSettings.AuthUsers;

            foreach (var user in users)
            {
                var appUser = new ApplicationUser()
                {
                    UserName = user.UserName,
                };

                if (await _userManager.FindByNameAsync(user.UserName) == null)
                {
                    var resultado = await _userManager.CreateAsync(appUser, user.Password);

                    if (resultado.Succeeded)
                    {
                        await _userManager.AddToRolesAsync(appUser, user.Roles);
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }
            }
        }
    }
}
