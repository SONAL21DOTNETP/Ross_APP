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
    public class CustomerPricingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CustomerPricingController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateCustomerPricing([FromBody] CreateCustomerPricingCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var pricingId = await _mediator.Send(command);
            return Ok(new { Id = pricingId });
        }

        [HttpPost("UpdateCustomerPricing")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateCustomerPricing([FromBody] UpdateCustomerPricingByIdCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteCustomerPricing")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteCustomerPricing([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteCustomerPricingCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllCustomerPricing()
        {
            var items = await _mediator.Send(new GetAllCustomerPricingQuery());
            return Ok(items);
        }

        [HttpGet("GetCustomerPricingById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCustomerPricingById([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetCustomerPricingByIdQuery(id));
            return Ok(item);
        }
    }
}
