using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllBoilerSeriesPartsMappingQuery() : IRequest<List<BoilerSeriesPartsMapping>>;
}
