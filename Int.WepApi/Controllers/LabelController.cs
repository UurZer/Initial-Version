using Core.Application.Requests;
using Core.Application.Responses;
using Int.Application.Features.Commands;
using Int.Application.Features.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Int.WepApi.Controllers
{
    public class LabelController : BaseController
    {
        #region [ POST ]

        [Route("Create/Label")]
        [HttpPost]
        public async Task<IActionResult> CreateLabel([FromBody] CreateCartCommand createLabelCommand)
        {
            CreatedCartItemResponse response = await Mediator.Send(createLabelCommand);
            return Ok(response);
        }

        #endregion

        #region [ GET ]

        [Route("Label/{ParentId}/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetLabelByIds(Guid parentId, Guid id)
        {
            GetLabelById getLabelByCode = new()
            {
                ParentId = parentId,
                Id = id
            };

            LabelResponse response = await Mediator.Send(getLabelByCode);
            return Ok(response);
        }

        [Route("Labels/{LabelUType}/{Level}")]
        [HttpGet]
        public async Task<IActionResult> GetAllLabelByLevel([FromBody] PageRequest pageRequest, string labelUType, int level)
        {
            GetListLabelQuery getByIdLabelQuery = new()
            {
                PageRequest = pageRequest,
                LabelUType = labelUType,
                Level = level
            };

            GetListResponse<GetListLabelListItemDto> response = await Mediator.Send(getByIdLabelQuery);
            return Ok(response);
        }

        #endregion


    }
}
