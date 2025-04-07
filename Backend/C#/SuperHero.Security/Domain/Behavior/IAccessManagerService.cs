using SuperHero.Security.Domain.Model;

namespace SuperHero.Security.Domain.Behavior
{
    public interface IAccessManagerService
    {
        public Task<bool> ValidateCredentials(User user);

        public Task<Token> GenerateToken(User user);
    }
}
