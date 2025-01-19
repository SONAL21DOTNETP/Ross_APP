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

        public BoilerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoiler(CreateBoilerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoiler(int id)
        {
            var result = await _mediator.Send(new DeleteBoilerCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBoiler(UpdateBoilerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoilers()
        {
            var result = await _mediator.Send(new GetAllBoilersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoilerById(int id)
        {
            var result = await _mediator.Send(new GetBoilerByIdQuery(id));
            return Ok(result);
        }
    }
}
