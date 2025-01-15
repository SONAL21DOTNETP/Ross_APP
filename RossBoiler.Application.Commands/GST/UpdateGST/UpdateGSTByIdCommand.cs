using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateGSTByIdCommand(int Id, decimal Rate, string Description) : IRequest<string>;
}