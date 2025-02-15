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
    public class HSNController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public HSNController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateHSN([FromBody] CreateHSNCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var hsnId = await _mediator.Send(command);
            return Ok(new { Id = hsnId });
        }

        [HttpPut("UpdateHSN")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateHSN([FromBody] UpdateHSNCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteHSN")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteHSN([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteHSNCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllHSN()
        {
            var items = await _mediator.Send(new GetAllHSNQuery());
            return Ok(items);
        }

        [HttpGet("GetHSNByFilter")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetHSNByFilter([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetHSNByFilterQuery(id));
            return Ok(item);
        }
    }
}
