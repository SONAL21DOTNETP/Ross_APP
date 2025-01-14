using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreatePackingCommand(string Name, string UsedFor, string Description) : IRequest<int>;
}