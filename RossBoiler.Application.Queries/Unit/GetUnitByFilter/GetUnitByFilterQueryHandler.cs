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
            var item =await _context.Units
                .FindAsync(new object[] { request.UnitID }, cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"Technician with ID {request.UnitID} not found");

            }
            return item;

        }
    }
}