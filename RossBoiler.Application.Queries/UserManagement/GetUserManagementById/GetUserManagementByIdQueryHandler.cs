using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Queries
{
    public class GetUserManagementByIdQueryHandler : IRequestHandler<GetUserManagementByIdQuery, UserManagement>
    {
        private readonly ApplicationDbContext _context;

        public GetUserManagementByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserManagement> Handle(GetUserManagementByIdQuery request, CancellationToken cancellationToken)
        {
            var userManagement = await _context.UserManagements
                .FindAsync(new object[] { request.UserManagementID }, cancellationToken);

            if (userManagement == null)
                throw new KeyNotFoundException($"UserManagement with ID {request.UserManagementID} not found.");

            return userManagement;
        }
    }
}
