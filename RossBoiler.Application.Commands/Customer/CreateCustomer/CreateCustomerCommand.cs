using MediatR;
using System.Net;

namespace RossBoiler.Application.Commands
{
    public record CreateCustomerCommand(string OrgName, string Description) : IRequest<int>;
}