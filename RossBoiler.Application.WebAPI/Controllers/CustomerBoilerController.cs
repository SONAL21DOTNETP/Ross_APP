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
    public class CustomerBoilersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CustomerBoilersController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("CreateCustomerBoilerCommand")]
        public async Task<IActionResult> CreateCustomerBoiler([FromBody] CreateCustomerBoilerCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var customerBoilerId = await _mediator.Send(command);
            return Ok(new { Id = customerBoilerId });
        }

        [HttpPost("UpdateCustomerBoiler")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateCustomerBoiler([FromBody] UpdateCustomerBoilerCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteCustomerBoiler")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteCustomerBoiler([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteCustomerBoilerCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("GetAllCustomerBoilersQuery")]
        public async Task<IActionResult> GetAllCustomerBoilers()
        {
            var customerBoilers = await _mediator.Send(new GetAllCustomerBoilersQuery());
            return Ok(customerBoilers);
        }

        [HttpGet("GetCustomerBoilerById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCustomerBoilerById([FromQuery] int id)
        {
            var customerBoiler = await _mediator.Send(new GetCustomerBoilerByIdQuery(id));
            return Ok(customerBoiler);
        }
    }
}
