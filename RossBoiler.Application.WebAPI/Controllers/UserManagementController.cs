using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RossBoiler.Application.Commands;
using RossBoiler.Application.Queries;
using RossBoiler.Application.WebAPI.Utils;
using RossBoiler.Common;

namespace YourApp.Application.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get All UserManagements
        [HttpGet]
        public async Task<ActionResult<List<UserManagement>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUserManagementsQuery());
            return Ok(result);
        }

        // Get UserManagement by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserManagement>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetUserManagementByIdQuery(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Create a new UserManagement
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateUserManagementCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // Update UserManagement
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, [FromBody] UpdateUserManagementCommand command)
        {
            if (id != command.UserManagementID)
            {
                return BadRequest("ID mismatch between route and body.");
            }

            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete UserManagement
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserManagementCommand(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
