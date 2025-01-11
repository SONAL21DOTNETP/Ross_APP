using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateItemByIdCommand(int Id, decimal Price) : IRequest<string>;
}
