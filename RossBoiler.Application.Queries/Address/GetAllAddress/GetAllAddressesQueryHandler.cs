using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, List<Address>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllAddressesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Addresses.ToListAsync(cancellationToken);
        }
    }
}