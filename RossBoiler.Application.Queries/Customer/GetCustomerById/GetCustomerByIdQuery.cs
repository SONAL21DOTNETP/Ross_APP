using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetCustomerByIdQuery(int CustomerID) : IRequest<Customer>;
}
