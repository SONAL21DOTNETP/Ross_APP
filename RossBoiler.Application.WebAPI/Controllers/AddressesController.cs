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
    public class AddressesController : ControllerBase{
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public AddressesController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
             _mediator = mediator;
             _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("CreateAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var addressId = await _mediator.Send(command);
            return Ok(new { Id = addressId });
        }

        [HttpPost("UpdateAddress")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommand command)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteAddress")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteAddress([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteAddressCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("GetAllAddresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _mediator.Send(new GetAllAddressesQuery());
            return Ok(addresses);
        }

        [HttpGet("GetAddressById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAddressById([FromQuery] int id)
        {
            var address = await _mediator.Send(new GetAddressByIdQuery(id));
            return Ok(address);
        } 


    }
}
