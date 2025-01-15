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
    public class BoilerSeriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoilerSeriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoilerSeries(CreateBoilerSeriesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoilerSeries(int id)
        {
            var result = await _mediator.Send(new DeleteBoilerSeriesCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBoilerSeries(UpdateBoilerSeriesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoilerSeries()
        {
            var result = await _mediator.Send(new GetAllBoilerSeriesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoilerSeriesById(int id)
        {
            var result = await _mediator.Send(new GetBoilerSeriesByIdQuery(id));
            return Ok(result);
        }
    }
}
