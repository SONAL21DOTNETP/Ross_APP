using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteCustomerBoilerCommand(int Id) : IRequest<string>;

}