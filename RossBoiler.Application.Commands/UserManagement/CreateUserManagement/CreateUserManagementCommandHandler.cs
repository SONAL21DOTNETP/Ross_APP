using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Commands
{
    public class CreateUserManagementCommandHandler : IRequestHandler<CreateUserManagementCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserManagementCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserManagementCommand request, CancellationToken cancellationToken)
        {
            var userManagement = new UserManagement
            {
                Role = request.Role,
                IsAdmin = request.IsAdmin
            };

            _context.UserManagements.Add(userManagement);
            await _context.SaveChangesAsync(cancellationToken);

            return userManagement.Id;
        }
    }
}
