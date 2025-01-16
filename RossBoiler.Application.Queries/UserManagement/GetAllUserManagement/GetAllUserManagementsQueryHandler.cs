using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllUserManagementsQueryHandler : IRequestHandler<GetAllUserManagementsQuery, List<UserManagement>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUserManagementsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserManagement>> Handle(GetAllUserManagementsQuery request, CancellationToken cancellationToken)
        {
            return await _context.UserManagements.ToListAsync(cancellationToken);
        }
    }
}
