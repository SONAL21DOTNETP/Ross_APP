using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteUserManagementCommand(int UserManagementID) : IRequest<int>;
}
