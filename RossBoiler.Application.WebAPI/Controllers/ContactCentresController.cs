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
    public class ContactCentresController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public ContactCentresController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }

        [HttpPost]
        [MapToApiVersion("CreateContactCentre")]
        public async Task<IActionResult> CreateContactCentre([FromBody] CreateContactCentreCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var contactCentreId = await _mediator.Send(command);
            return Ok(new { Id = contactCentreId });
        }

        [HttpPost("UpdateContactCentre")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateContactCentre([FromBody] UpdateContactCentreCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteContactCentre")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteContactCentre([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteContactCentreCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("GetAllContactCentres")]
        public async Task<IActionResult> GetAllContactCentres()
        {
            var items = await _mediator.Send(new GetAllContactCentresQuery());
            return Ok(items);
        }

        [HttpGet("GetContactCentreById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetContactCentreById([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetContactCentreByIdQuery(id));
            return Ok(item);
        }
    }
}

