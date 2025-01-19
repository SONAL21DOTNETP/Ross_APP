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

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get All Customers
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }

        // Get Customer by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCustomerByIdQuery(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Create a new Customer
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, result);
        }

        // Update Customer
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.CustomerID)
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

        // Delete Customer
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCustomerCommand(id));
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
