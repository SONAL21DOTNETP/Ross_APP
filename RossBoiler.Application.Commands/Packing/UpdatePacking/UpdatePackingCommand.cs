using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdatePackingCommand(int PackingID, string Name, string UsedFor, string Description) : IRequest<string>;
}