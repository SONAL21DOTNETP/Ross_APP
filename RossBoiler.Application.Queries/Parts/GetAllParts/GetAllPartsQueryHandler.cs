using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQuery, List<Parts>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllPartsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Parts>> Handle(GetAllPartsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Parts.ToListAsync(cancellationToken);
        }
    }
}