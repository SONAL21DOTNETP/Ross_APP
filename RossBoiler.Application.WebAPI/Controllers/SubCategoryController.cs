using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RossBoiler.Application.Commands;
using RossBoiler.Application.Queries;
using RossBoiler.Application.WebAPI.Utils;
using RossBoiler.Common;

namespace RossBoiler.Application.WebAPI
{
    [ApiController]
    [Route("api/v{version}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public SubCategoryController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateSubCategory([FromBody] CreateSubCategoryCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var subcategoryId = await _mediator.Send(command);            
            return Ok(new { Id = subcategoryId });
        }


        [HttpPut("UpdateSubCategory")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateSubCategory([FromBody] UpdateSubCategoryByIdCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteSubCategory")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteSubCategory([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteSubCategoryCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllSubCategory()
        {
            var Items = await _mediator.Send(new GetAllSubCategoryQuery());
            return Ok(Items);
        }


        [HttpGet("GetSubCategoryById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetSubCategoryById([FromQuery]int id)
        {
            var Item = await _mediator.Send(new GetSubCategoryByIdQuery(id));
            return Ok(Item);
        }
    }
}
