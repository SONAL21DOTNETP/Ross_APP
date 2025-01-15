using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record CreateBoilerCommand(string Head, string Description) : IRequest<int>;
}
