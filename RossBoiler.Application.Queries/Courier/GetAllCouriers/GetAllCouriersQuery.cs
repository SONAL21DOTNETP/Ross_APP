using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllCouriersQuery() : IRequest<List<Courier>>;
}
