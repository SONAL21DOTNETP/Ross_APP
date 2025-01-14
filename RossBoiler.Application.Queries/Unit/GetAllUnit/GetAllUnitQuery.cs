using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetAllUnitQuery() : IRequest<List<Unit>>;
}