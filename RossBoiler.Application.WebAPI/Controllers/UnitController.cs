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
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public UnitController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateUnit([FromBody] CreateUnitCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var unitId = await _mediator.Send(command);
            return Ok(new { Id = unitId });
        }

        [HttpPost("UpdateUnit")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateUnit([FromBody] UpdateUnitCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteUnit")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteUnit([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteUnitCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllUnit()
        {
            var items = await _mediator.Send(new GetAllUnitQuery());
            return Ok(items);
        }

        [HttpGet("GetUnitByFilter")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetUnitByFilter([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetUnitByFilterQuery(id));
            return Ok(item);
        }
    }
}
