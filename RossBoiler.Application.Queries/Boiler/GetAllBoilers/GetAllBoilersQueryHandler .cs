using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllBoilersQueryHandler : IRequestHandler<GetAllBoilersQuery, List<Boiler>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllBoilersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Boiler>> Handle(GetAllBoilersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Boilers.ToListAsync(cancellationToken);
        }
    }

    
}
