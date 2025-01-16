using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateUserManagementCommand(string Role, bool IsAdmin) : IRequest<int>;
}
