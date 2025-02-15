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
    public class BoilerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public BoilerController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateBoiler(CreateBoilerCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var boilerId = await _mediator.Send(command);
            return Ok(new { Id = boilerId });
        }

        [HttpDelete("DeleteBoiler")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteBoiler(int id)
        {

           
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteBoilerCommand(id));
            return Ok(new { Message = message });
        }

        [HttpPut("UpdateBoiler")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateBoiler(UpdateBoilerCommand command)
        {
           
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllBoilers()
        {
            var result = await _mediator.Send(new GetAllBoilersQuery());
            return Ok(result);
        }

        [HttpGet("GetBoilerById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetBoilerById(int id)
        {
            var result = await _mediator.Send(new GetBoilerByIdQuery(id));
            return Ok(result);
        }
    }
}
