using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetPackingByFilterQuery(int PackingID) : IRequest<Packing>;
}