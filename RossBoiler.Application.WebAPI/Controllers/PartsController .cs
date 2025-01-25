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
    public class PartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public PartsController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreatePart([FromBody] CreatePartsCommand command)
        {
            
            var id = _correlationIdProvider.CorrelationId;
            var partsId = await _mediator.Send(command);
            return Ok(new { Id = partsId });
        }

        [HttpPost("UpdatePart")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdatePart([FromBody] UpdatePartsCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }


        [HttpDelete("DeletePart")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeletePart(int id)
        {
            
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeletePartsCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllParts()
        {
            var parts = await _mediator.Send(new GetAllPartsQuery());
            return Ok(parts);
        }

        [HttpGet("GetPartById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetPartById(int id)
        {
            var part = await _mediator.Send(new GetPartsByFilterQuery(id));
            return Ok(part);
        }
    }
} 