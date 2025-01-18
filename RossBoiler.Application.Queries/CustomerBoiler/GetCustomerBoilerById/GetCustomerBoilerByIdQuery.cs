
using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetCustomerBoilerByIdQuery(int Id) : IRequest<CustomerBoiler>;
}
