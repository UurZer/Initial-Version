using Int.Application.Features.Commands;
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

        [Route("Product")]
        [HttpGet]
        public async Task<IActionResult> GetProductByCode([FromBody] CreateProductCommand createProductCommand)
        {
            CreatedProductResponse response = await Mediator.Send(createProductCommand);
            return Ok(response);
        }

        #endregion


    }
}
