using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Commands
{
    public class UpdateUserManagementCommandHandler : IRequestHandler<UpdateUserManagementCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserManagementCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserManagementCommand request, CancellationToken cancellationToken)
        {
            var userManagement = await _context.UserManagements.FindAsync(new object[] { request.UserManagementID }, cancellationToken);

            if (userManagement == null)
                throw new KeyNotFoundException($"UserManagement with ID {request.UserManagementID} not found.");

            userManagement.Role = request.Role;
            userManagement.IsAdmin = request.IsAdmin;

            _context.UserManagements.Update(userManagement);
            await _context.SaveChangesAsync(cancellationToken);

            return userManagement.Id;
        }
    }
}
