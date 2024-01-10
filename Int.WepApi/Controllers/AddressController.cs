using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize()]
    public class AddressController : BaseController
    {
        #region [ POST ]

        [Route("Create/Address")]
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand createAddressCommand)
        {
            CreatedAddressResponse response = await Mediator.Send(createAddressCommand);
            return Ok(response);
        }

        #endregion

        #region [ GET ]

        [Route("Current/User/Address")]
        [HttpGet]
        public async Task<IActionResult> GetAllAddresssByLabel()
        {
            GetListResponse<GetListAddressListItemDto> response = await Mediator.Send(new GetListAddressQuery());

            return Ok(response);
        }

        #endregion
    }
}
