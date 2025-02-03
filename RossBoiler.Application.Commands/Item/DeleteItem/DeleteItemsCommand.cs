using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteItemCommand(int ID) : IRequest<string>;
}