using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllCouriersQueryHandler : IRequestHandler<GetAllCouriersQuery, List<Courier>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCouriersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Courier>> Handle(GetAllCouriersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Couriers.ToListAsync(cancellationToken);
        }
    }
}
