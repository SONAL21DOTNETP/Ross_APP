using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateUnitCommand(string Name, string Code, string Description) : IRequest<int>;
}