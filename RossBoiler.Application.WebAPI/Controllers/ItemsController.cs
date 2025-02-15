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
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public ItemsController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateItemCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var productId = await _mediator.Send(command);            
            return Ok(new { Id = productId });
        }


        [HttpPut("UpdateItems")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateItemByIdCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }


        [HttpDelete("DeleteItems")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteItems([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteItemCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllProduct()
        {
            var Items = await _mediator.Send(new GetAllItemQuery());
            return Ok(Items);
        }


        [HttpGet("GetItemById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetItemById([FromQuery]int id)
        {
            var Item = await _mediator.Send(new GetItemByIdQuery(id));
            return Ok(Item);
        }
    }
}
