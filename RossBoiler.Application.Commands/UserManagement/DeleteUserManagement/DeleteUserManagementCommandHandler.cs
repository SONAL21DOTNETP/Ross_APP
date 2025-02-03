using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Commands
{
    public class DeleteUserManagementCommandHandler : IRequestHandler<DeleteUserManagementCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserManagementCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteUserManagementCommand request, CancellationToken cancellationToken)
        {
            var userManagement = await _context.UserManagements.FindAsync(new object[] { request.UserManagementID }, cancellationToken);

            if (userManagement == null)
                throw new KeyNotFoundException($"UserManagement with ID {request.UserManagementID} not found.");

            _context.UserManagements.Remove(userManagement);
            await _context.SaveChangesAsync(cancellationToken);

        
            return $"UserManagement with ID {request.UserManagementID} delete successfully.";
        }
    }
}
