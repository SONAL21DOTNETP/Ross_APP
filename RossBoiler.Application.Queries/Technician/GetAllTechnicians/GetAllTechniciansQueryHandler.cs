using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllTechniciansQueryHandler : IRequestHandler<GetAllTechniciansQuery, List<Technician>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllTechniciansQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Technician>> Handle(GetAllTechniciansQuery request, CancellationToken cancellationToken)
        {
            return await _context.Technicians.ToListAsync(cancellationToken);
        }
    }
}
