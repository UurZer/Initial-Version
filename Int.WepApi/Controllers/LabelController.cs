using Int.Application.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LabelController : BaseController
    {
        #region [ POST ]

        [Route("Create/Label")]
        [HttpPost]
        public async Task<IActionResult> CreateLabel([FromBody] CreateLabelCommand createLabelCommand)
        {
            CreatedLabelResponse response = await Mediator.Send(createLabelCommand);
            return Ok(response);
        }

        #endregion

        #region [ GET ]

        [Route("Label")]
        [HttpGet]
        public async Task<IActionResult> GetLabelByCode([FromBody] CreateLabelCommand createLabelCommand)
        {
            CreatedLabelResponse response = await Mediator.Send(createLabelCommand);
            return Ok(response);
        }

        #endregion


    }
}
