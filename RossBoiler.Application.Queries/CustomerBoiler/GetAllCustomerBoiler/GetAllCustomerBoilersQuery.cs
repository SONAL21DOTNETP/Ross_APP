

using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllCustomerBoilersQuery() : IRequest<List<CustomerBoiler>>;
}
