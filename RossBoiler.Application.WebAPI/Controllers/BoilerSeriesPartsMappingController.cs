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
    public class BoilerSeriesPartsMappingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoilerSeriesPartsMappingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoilerSeriesPartsMapping(CreateBoilerSeriesPartsMappingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoilerSeriesPartsMapping(int id)
        {
            var result = await _mediator.Send(new DeleteBoilerSeriesPartsMappingCommand(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBoilerSeriesPartsMapping(UpdateBoilerSeriesPartsMappingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllBoilerSeriesPartsMapping()
        {
            var items = await _mediator.Send(new GetAllBoilerSeriesPartsMappingQuery());
            return Ok(items);
        }

        [HttpGet("GetBoilerSeriesPartsMappingByIdQuery")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetBoilerSeriesPartsMappingById([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetBoilerSeriesPartsMappingByIdQuery(id));
            return Ok(item);
        }
    }
}
