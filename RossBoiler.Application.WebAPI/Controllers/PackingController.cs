using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RossBoiler.Application.Commands;
using RossBoiler.Application.Queries;
using RossBoiler.Application.WebAPI.Utils;
using RossBoiler.Common;

namespace YourApp.Application.WebAPI
{
    [ApiController]
    [Route("api/v{version}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class PackingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public PackingController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreatePacking([FromBody] CreatePackingCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var packingId = await _mediator.Send(command);
            return Ok(new { Id = packingId });
        }

        [HttpPost("UpdatePacking")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdatePacking([FromBody] UpdatePackingCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeletePacking")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeletePacking([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeletePackingCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllPacking()
        {
            var items = await _mediator.Send(new GetAllPackingQuery());
            return Ok(items);
        }

        [HttpGet("GetPackingByFilter")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetPackingByFilter([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetPackingByFilterQuery(id));
            return Ok(item);
        }
    }
}
