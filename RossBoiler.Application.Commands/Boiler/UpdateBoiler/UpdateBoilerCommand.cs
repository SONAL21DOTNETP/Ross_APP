using MediatR;
using System.Net;


namespace RossBoiler.Application.Commands
{
    public record UpdateBoilerCommand(int Id, string Head, string Description) : IRequest<string>;
}
