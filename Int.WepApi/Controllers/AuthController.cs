using Int.Identity.Features.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : BaseController
    {
        #region [ POST ]

        [HttpPost("Auth/Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand userLoginCommand)
        {
            UserLoginResponse response = await Mediator.Send(userLoginCommand);
            return Ok(response);
        }

        [HttpPost("Auth/Register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterCommand userRegisterCommand)
        {
            UserRegisterResponse response = await Mediator.Send(userRegisterCommand);
            return Ok(response);
        }

        #endregion
    }
}
