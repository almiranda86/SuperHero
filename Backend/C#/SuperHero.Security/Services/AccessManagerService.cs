using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperHero.Security.Domain.Behavior;
using SuperHero.Security.Domain.Model;
using SuperHero.Security.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace SuperHero.Security.Service
{
    public class AccessManagerService : IAccessManagerService
    {
        private const string ROLES = "roles";
        private readonly IOptions<TokenSettings> _tokenSettings;
        private readonly ISigningConfigurations _signingConfigurations;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccessManagerService(IOptions<TokenSettings> tokenSettings,
                                    ISigningConfigurations signingConfigurations,
                                    UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager)
        {
            _tokenSettings = tokenSettings;
            _signingConfigurations = signingConfigurations;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Token> GenerateToken(User user)
        {
            var existingUser = await _userManager.FindByNameAsync(user.UserID);
            var userRoles = await _userManager.GetRolesAsync(existingUser);
            string roles = string.Join(",", userRoles);

            ClaimsIdentity identity = new(new GenericIdentity(user.UserID!, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserID!),
                        new Claim(ROLES, roles)
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenSettings.Value.Seconds);


            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenSettings.Value.Issuer,
                Audience = _tokenSettings.Value.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK"
            };
        }

        public async Task<bool> ValidateCredentials(User user)
        {
            bool credenciaisValidas = false;
            if (user is not null && !String.IsNullOrWhiteSpace(user.UserID))
            {
                var userIdentity = await _userManager.FindByNameAsync(user.UserID);
                if (userIdentity is not null)
                {
                    var resultadoLogin = await _signInManager.CheckPasswordSignInAsync(userIdentity, user.Password, false);
                    if (resultadoLogin.Succeeded)
                    {
                        credenciaisValidas = _userManager.IsInRoleAsync(userIdentity, RolesConstants.ROOT_API_ACCESS).Result;
                    }
                }
            }

            return credenciaisValidas;
        }
    }
}
