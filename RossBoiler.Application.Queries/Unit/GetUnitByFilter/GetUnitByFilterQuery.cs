using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetUnitByFilterQuery(int UnitID) : IRequest<Unit>;
}