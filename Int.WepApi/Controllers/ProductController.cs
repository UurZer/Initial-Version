using Core.Application.Requests;
using Core.Application.Responses;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : BaseController
    {
        #region [ POST ]

        [Route("Create/Product")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            CreatedProductResponse response = await Mediator.Send(createProductCommand);
            return Ok(response);
        }

        #endregion

        #region [ GET ]

        [Route("Products/{LabelId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllProductsByLabel([FromBody] PageRequest pageRequest, Guid labelId)
        {
            GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest, LabelId = labelId };

            GetListResponse<GetListProductListItemDto> response = await Mediator.Send(getListProductQuery);

            return Ok(response);
        }

        #endregion


    }
}
