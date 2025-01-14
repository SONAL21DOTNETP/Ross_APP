using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetAllPackingQuery() : IRequest<List<Packing>>;
}