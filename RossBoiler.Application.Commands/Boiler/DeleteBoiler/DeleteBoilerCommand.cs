using MediatR;
using System.Net;

namespace RossBoiler.Application.Commands
{
    public record DeleteBoilerCommand(int Id) : IRequest<string>;
}
