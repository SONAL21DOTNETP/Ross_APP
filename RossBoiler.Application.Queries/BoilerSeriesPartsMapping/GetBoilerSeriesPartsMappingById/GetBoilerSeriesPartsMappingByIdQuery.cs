using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetBoilerSeriesPartsMappingByIdQuery(int Id) : IRequest<BoilerSeriesPartsMapping>;
}
