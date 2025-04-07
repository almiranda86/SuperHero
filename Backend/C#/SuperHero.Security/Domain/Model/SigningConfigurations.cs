using Microsoft.IdentityModel.Tokens;
using SuperHero.Security.Domain.Behavior;
using System.Text;

namespace SuperHero.Security.Domain.Model
{
    public class SigningConfigurations : ISigningConfigurations
    {
        public Guid Id { get; } = Guid.NewGuid();
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations(string secretJwtKey)
        {
            Key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretJwtKey));

            SigningCredentials = new(
                Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
