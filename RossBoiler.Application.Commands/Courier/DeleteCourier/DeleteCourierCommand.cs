using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record DeleteCourierCommand(int Id) : IRequest<string>;
}
