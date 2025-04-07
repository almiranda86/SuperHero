using MediatR;
using SuperHero.Service.DTO;
using SuperHero.Security.Domain.Behavior;

namespace SuperHero.Service.Handlers
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IAccessManagerService _accessManagerService;


        public LoginUserRequestHandler(IAccessManagerService accessManagerService)
        {
            _accessManagerService = accessManagerService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            LoginUserResponse response = new LoginUserResponse();

            if (request is not null && await _accessManagerService.ValidateCredentials(request.User))
            {
                response.Token = await _accessManagerService.GenerateToken(request.User);
                return response;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
