using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateUserManagementCommand(
        int UserManagementID,
        string Role,
        bool IsAdmin
    ) : IRequest<string>;
}
