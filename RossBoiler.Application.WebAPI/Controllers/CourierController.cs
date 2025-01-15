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
    public class CourierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourier(CreateCourierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourier(int id)
        {
            var result = await _mediator.Send(new DeleteCourierCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCourier(UpdateCourierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCouriers()
        {
            var result = await _mediator.Send(new GetAllCouriersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourierById(int id)
        {
            var result = await _mediator.Send(new GetCourierByIdQuery(id));
            return Ok(result);
        }
    }
}
