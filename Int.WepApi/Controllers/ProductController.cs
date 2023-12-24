using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize()]
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
        [HttpPost]
        public async Task<IActionResult> GetAllProductsByLabel([FromBody] DynamicQuery dynamicQuery, [FromQuery] PageRequest pageRequest, Guid labelId)
        {
            GetListDynamicProductQuery productQuery = new() {  LabelId = labelId, DynamicQuery = dynamicQuery, PageRequest = pageRequest };

            GetListResponse<GetListProductListItemDto> response = await Mediator.Send(productQuery);

            return Ok(response);
        }

        [Route("Product/{productId}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            GetByIdProductQuery productQuery = new() { Id = productId };

            GetByIdProductResponse response = await Mediator.Send(productQuery);

            return Ok(response);
        }

        #endregion


    }
}
