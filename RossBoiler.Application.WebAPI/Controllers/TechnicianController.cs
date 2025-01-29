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
    public class TechnicianController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public TechnicianController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateTechnician([FromBody] CreateTechnicianCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var categoryId = await _mediator.Send(command);
            return Ok(new { Id = categoryId });
        }


        [HttpPost("UpdateTechnician")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateTechnician([FromBody] UpdateTechnicianCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteTechnician")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteTechnician([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteTechnicianCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllTechnicians()
        {
            var Items = await _mediator.Send(new GetAllTechniciansQuery());
            return Ok(Items);
        }

        [HttpGet("GetTechnicianById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetTechnicianById([FromQuery] int id)
        {
            var Item = await _mediator.Send(new GetTechnicianByIdQuery(id));
            return Ok(Item);
        }
    }
}
