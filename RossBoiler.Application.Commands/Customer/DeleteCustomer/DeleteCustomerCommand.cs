using MediatR;
using System.Net;

namespace RossBoiler.Application.Commands
{
    public record DeleteCustomerCommand(int CustomerID) : IRequest<string>;
}