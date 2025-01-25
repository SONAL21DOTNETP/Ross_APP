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
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CustomerController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var customerId = await _mediator.Send(command);
            return Ok(new { Id = customerId });
        }
        [HttpPost("UpdateCustomerCommand")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }
        [HttpDelete("DeleteCustomer")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteCustomer([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok(new { Message = message });
        }
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var Items = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(Items);
        }
        [HttpGet("GetCustomerById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            var Item = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(Item);
        }
    }
}
