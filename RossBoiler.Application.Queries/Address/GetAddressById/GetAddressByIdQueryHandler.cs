using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Address>
    {
        private readonly ApplicationDbContext _context;

        public GetAddressByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Address> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Addresses.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}