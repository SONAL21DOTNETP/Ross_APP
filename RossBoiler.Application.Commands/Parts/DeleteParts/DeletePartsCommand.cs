using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeletePartsCommand(int Id) : IRequest<string>;
}