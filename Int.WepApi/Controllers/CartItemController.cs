using Core.Application.Responses;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    public class CartItemController : BaseController
    {
        #region [ POST ]

        [Route("Create/CartItem")]
        [HttpPost]
        public async Task<IActionResult> CreateCartItem([FromBody] CreateCartItemCommand command)
        {
            List<CreatedCartItemResponse> response = await Mediator.Send(command);
            return Ok(response);
        }

        [Route("Delete/CartItem")]
        [HttpDelete]
        public async Task<IActionResult> CreateCartItem([FromQuery] DeleteCartItemCommand command)
        {
            DeletedCartItemResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        #endregion

        #region [ GET ]

        [Route("Current/User/CartItem")]
        [HttpGet]
        public async Task<IActionResult> GetAllCartItemsByUser([FromQuery] GetListCartItemQuery cartQuery)
        {
            GetListResponse<GetListCartItemsListItemDto> response = await Mediator.Send(cartQuery);
            return Ok(response);
        }

        #endregion
    }
}
