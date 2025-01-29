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
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public UserManagementController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateUserManagement([FromBody] CreateUserManagementCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var UserManagementID = await _mediator.Send(command);
            return Ok(new { Id = UserManagementID });
        }


        [HttpPost("UpdateUserManagement")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateUserManagement([FromBody] UpdateUserManagementCommand command)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpDelete("DeleteUserManagement")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteUserManagement([FromQuery] int id)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteUserManagementCommand(id));
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllUserManagements()
        {
            var Items = await _mediator.Send(new GetAllUserManagementsQuery());
            return Ok(Items);
        }


        [HttpGet("GetUserManagementById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetUserManagementById([FromQuery] int id)
        {
            var Item = await _mediator.Send(new GetUserManagementByIdQuery(id));
            return Ok(Item);
        }
    }
}
