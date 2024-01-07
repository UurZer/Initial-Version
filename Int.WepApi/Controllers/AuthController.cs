using Int.Application.Features.Queries;
using Int.Identity.Features.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using Core.Application.Responses;

namespace WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : BaseController
    {
        #region [ POST ]

        [AllowAnonymous]
        [HttpPost("Auth/Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommand userLoginCommand)
        {
            UserLoginResponse response = await Mediator.Send(userLoginCommand);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Auth/Register")]
        public async Task<ActionResult> Register([FromBody] UserRegisterCommand userRegisterCommand)
        {
            UserRegisterResponse response = await Mediator.Send(userRegisterCommand);
            return Ok(response);
        }

        #endregion

        #region [ GET ]

        [HttpGet("Auth/User")]
        public async Task<IActionResult> GetAuthUser([FromQuery] GetByIdUserQuery query)
        {
            GetByIdUserResponse response = await Mediator.Send(query);
            return Ok(response);
        }

        #endregion
    }
}
