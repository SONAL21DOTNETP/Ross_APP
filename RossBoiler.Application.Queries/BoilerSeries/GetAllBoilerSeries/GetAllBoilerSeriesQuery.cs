using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllBoilerSeriesQuery() : IRequest<List<BoilerSeries>>;
}
