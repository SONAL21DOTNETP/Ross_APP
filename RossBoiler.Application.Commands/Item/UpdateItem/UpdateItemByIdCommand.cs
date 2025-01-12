using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateItemByIdCommand(int Id, string Name, decimal Price) : IRequest<string>;
}
