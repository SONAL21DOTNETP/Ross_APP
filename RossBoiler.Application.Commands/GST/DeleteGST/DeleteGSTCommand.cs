using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteGSTCommand(int Id) : IRequest<string>;

}