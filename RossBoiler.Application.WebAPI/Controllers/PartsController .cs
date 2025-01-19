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

        public PartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart([FromBody] CreatePartsCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePart([FromBody] UpdatePartsCommand command)
        {
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(int id)
        {
            var message = await _mediator.Send(new DeletePartsCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParts()
        {
            var parts = await _mediator.Send(new GetAllPartsQuery());
            return Ok(parts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartById(int id)
        {
            var part = await _mediator.Send(new GetPartsByFilterQuery(id));
            return Ok(part);
        }
    }
} 