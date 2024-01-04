using Core.Application.Responses;
using Int.Application.Features.OrderTransactions.Upsert;
using Int.Application.Features.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    public class OrderTransactionController : BaseController
    {
        #region [ POST ]

        [Route("Create/OrderTransaction")]
        [HttpPost]
        public async Task<IActionResult> CreateOrderTransaction([FromBody] CreateOrderTransactionCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        #endregion

        #region [ GET ]

        [Route("OrderTransactions")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrderTransactionsByUser([FromQuery] GetListOrderTransactionQuery query)
        {
            GetListResponse<GetListOrderTransactionListItemDto> response = await Mediator.Send(query);
            return Ok(response);
        }

        [Route("OrderTransactions/OrderGroup")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrderTransactionsByGroup([FromQuery] GetByIdOrderTransactionQuery query)
        {
            GetListResponse<GetByIdOrderTransactionResponse> response = await Mediator.Send(query);
            return Ok(response);
        }

        #endregion
    }
}
