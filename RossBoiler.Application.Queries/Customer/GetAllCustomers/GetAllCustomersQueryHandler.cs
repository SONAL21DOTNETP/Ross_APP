using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Queries
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCustomersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }
    }
}
