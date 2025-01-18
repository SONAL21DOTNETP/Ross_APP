

using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllAddressesQuery() : IRequest<List<Address>>;
}