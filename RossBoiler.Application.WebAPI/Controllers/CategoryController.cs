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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CategoryController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var categoryId = await _mediator.Send(command);            
            return Ok(new { Id = categoryId });
        }


        [HttpPost("UpdateCategory")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryByIdCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteCategory")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllCategory()
        {
            var Items = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(Items);
        }


        [HttpGet("GetCategoryById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCategoryById([FromQuery]int id)
        {
            var Item = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(Item);
        }
    }
}
