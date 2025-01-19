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
    public class TechnicianController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnicianController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get All Technicians
        [HttpGet]
        public async Task<ActionResult<List<Technician>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllTechniciansQuery());
            return Ok(result);
        }

        // Get Technician by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Technician>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTechnicianByIdQuery(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Create a new Technician
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTechnicianCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // Update Technician
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, [FromBody] UpdateTechnicianCommand command)
        {
            if (id != command.TechnicianID)
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

        // Delete Technician
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTechnicianCommand(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
