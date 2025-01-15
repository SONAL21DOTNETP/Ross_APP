using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record CreateCourierCommand(string BasicDetails, string Contacts, string Address) : IRequest<int>;
}
