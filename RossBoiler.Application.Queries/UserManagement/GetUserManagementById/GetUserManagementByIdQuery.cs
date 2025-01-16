using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetUserManagementByIdQuery(int UserManagementID) : IRequest<UserManagement>;
}
