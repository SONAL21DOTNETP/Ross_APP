using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllPackingQueryHandler : IRequestHandler<GetAllPackingQuery, List<Packing>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllPackingQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Packing>> Handle(GetAllPackingQuery request, CancellationToken cancellationToken)
        {
            return await _context.Packings.ToListAsync(cancellationToken);
        }
    }
}