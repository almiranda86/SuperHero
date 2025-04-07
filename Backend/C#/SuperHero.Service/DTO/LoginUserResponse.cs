using SuperHero.Core.Service;
using SuperHero.Security.Domain.Model;

namespace SuperHero.Service.DTO
{
    public class LoginUserResponse : ServiceResponse
    {
       public Token Token { get; set; }
    }
}
