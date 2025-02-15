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
    public class BoilerSeriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public BoilerSeriesController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateBoilerSeries(CreateBoilerSeriesCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var BoilerSeriesId = await _mediator.Send(command);
            return Ok(new { Id = BoilerSeriesId });
        }

        [HttpDelete("DeleteBoilerSeries")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteBoilerSeries(int id)
        {
            
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteBoilerSeriesCommand(id));
            return Ok(new { Message = message });
        }

        [HttpPut("UpdateBoilerSeries")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateBoilerSeries(UpdateBoilerSeriesCommand command)
        {
            
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllBoilerSeries()
        {
            var result = await _mediator.Send(new GetAllBoilerSeriesQuery());
            return Ok(result);
        }

        [HttpGet("GetBoilerSeriesById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetBoilerSeriesById(int id)
        {
            var result = await _mediator.Send(new GetBoilerSeriesByIdQuery(id));
            return Ok(result);
        }
    }
}
