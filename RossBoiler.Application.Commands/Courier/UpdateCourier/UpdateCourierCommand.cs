using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record UpdateCourierCommand(
        int Id,
        string BasicDetails,
        string Contacts,
        string Address
    ) : IRequest<string>;
}
