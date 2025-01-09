using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateItemCommand(string Name, decimal Price) : IRequest<int>;
}
