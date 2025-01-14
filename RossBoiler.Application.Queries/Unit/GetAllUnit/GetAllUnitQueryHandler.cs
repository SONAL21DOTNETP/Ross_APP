using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
namespace RossBoiler.Application.Queries
{
    public class GetAllUnitQueryHandler : IRequestHandler<GetAllUnitQuery, List<Unit>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllUnitQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unit>> Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
        {
            return await _context.Units.ToListAsync(cancellationToken);
        }
    }
}