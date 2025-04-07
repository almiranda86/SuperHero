using MediatR;
using SuperHero.Security.Domain.Model;

namespace SuperHero.Service.DTO
{
    public record LoginUserRequest : IRequest<LoginUserResponse>
    {
        public User User { get; set; }
    }
}
