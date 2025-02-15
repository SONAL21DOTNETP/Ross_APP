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
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public BoilerSeriesPartsMappingController(IMediator mediator, ICorrelationIdProvider correlationIdProvider)
        {
            _mediator = mediator;
            _correlationIdProvider = correlationIdProvider;
        }
        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> CreateBoilerSeriesPartsMapping(CreateBoilerSeriesPartsMappingCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var BoilerSeriesPartsMappingId = await _mediator.Send(command);
            return Ok(new { Id = BoilerSeriesPartsMappingId });
        }

        [HttpDelete("DeleteBoilerSeriesPartsMapping")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> DeleteBoilerSeriesPartsMapping(int id)
        {
            
            var correlationId = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(new DeleteBoilerSeriesPartsMappingCommand(id));
            return Ok(new { Message = message });
        }

        [HttpPut("UpdateBoilerSeriesPartsMapping")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> UpdateBoilerSeriesPartsMapping(UpdateBoilerSeriesPartsMappingCommand command)
        {
            var id = _correlationIdProvider.CorrelationId;
            var message = await _mediator.Send(command);
            return Ok(new { Message = message });
        }

        

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllBoilerSeriesPartsMapping()
        {
            var items = await _mediator.Send(new GetAllBoilerSeriesPartsMappingQuery());
            return Ok(items);
        }

        [HttpGet("GetBoilerSeriesPartsMappingById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetBoilerSeriesPartsMappingById([FromQuery] int id)
        {
            var item = await _mediator.Send(new GetBoilerSeriesPartsMappingByIdQuery(id));
            return Ok(item);
        }
    }
}
