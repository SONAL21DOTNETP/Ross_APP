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
    public class CourierController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CourierController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateCourier(CreateCourierCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var courierId = await _mediator.Send(command);
            return Ok(new { Id = courierId });
        }

        [HttpDelete("DeleteCourier")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteCourier(int id)
        {
            
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteCourierCommand(id));
            return Ok(new { Message = message });
        }

        [HttpPost("UpdateCourier")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateCourier(UpdateCourierCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllCouriers()
        {
            var result = await _mediator.Send(new GetAllCouriersQuery());
            return Ok(result);
        }

        [HttpGet("GetCourierById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCourierById(int id)
        {
            var result = await _mediator.Send(new GetCourierByIdQuery(id));
            return Ok(result);
        }
    }
}
