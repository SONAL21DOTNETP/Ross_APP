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
    public class GSTController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public GSTController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateGST([FromBody] CreateGSTCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var gstId = await _mediator.Send(command);
            return Ok(new { Id = gstId });
        }

        [HttpPost("UpdateGST")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateGST([FromBody] UpdateGSTByIdCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteGST")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteGST([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteGSTCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllGST()
        {
            var items = await _mediator.Send(new GetAllGSTQuery());
            return Ok(items);
        }

        [HttpGet("GetGSTById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetGSTById([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetGSTByIdQuery(id));
            return Ok(item);
        }
    }
}
