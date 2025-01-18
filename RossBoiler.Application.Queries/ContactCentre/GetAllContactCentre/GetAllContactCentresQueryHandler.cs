using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllContactCentresQueryHandler : IRequestHandler<GetAllContactCentresQuery, List<ContactCentre>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllContactCentresQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactCentre>> Handle(GetAllContactCentresQuery request, CancellationToken cancellationToken)
        {
            return await _context.ContactCentres.ToListAsync(cancellationToken);
        }
    }
}
