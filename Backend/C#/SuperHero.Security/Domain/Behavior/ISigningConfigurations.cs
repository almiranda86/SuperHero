using Microsoft.IdentityModel.Tokens;

namespace SuperHero.Security.Domain.Behavior
{
    public interface ISigningConfigurations
    {
        public Guid Id { get; }
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }
    }
}
