using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetBoilerSeriesByIdQuery(int Id) : IRequest<BoilerSeries>;
}
