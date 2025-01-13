using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetUnitByFilterQueryHandler : IRequestHandler<GetUnitByFilterQuery, Unit>
    {
        private readonly ApplicationDbContext _context;
        public GetUnitByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(GetUnitByFilterQuery request, CancellationToken cancellationToken)
        {
            return await _context.Units
                .FindAsync(new object[] { request.UnitID }, cancellationToken);
            
        }
    }
}