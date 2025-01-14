using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeletePackingCommand(int PackingID) : IRequest<int>;
}