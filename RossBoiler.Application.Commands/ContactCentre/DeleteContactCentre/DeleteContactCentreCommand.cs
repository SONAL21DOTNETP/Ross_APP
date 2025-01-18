

using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteContactCentreCommand(int Id) : IRequest<string>;
}