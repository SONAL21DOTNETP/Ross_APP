using MediatR;
using System.Net;

namespace RossBoiler.Application.Commands
{
    public record UpdateCustomerCommand(int CustomerID, string OrgName, string Description) : IRequest<string>;
}
