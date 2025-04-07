using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperHero.API.Extensions;
using SuperHero.Service.DTO;
using System.Net;

namespace SuperHero.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(LoginUserResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public Task<IActionResult> Post([FromBody] LoginUserRequest loginUserRequest, CancellationToken cancellationToken)
        {
            return this.HandleQueryRequest<LoginUserRequest, LoginUserResponse>(loginUserRequest, cancellationToken);
        }
    }
}