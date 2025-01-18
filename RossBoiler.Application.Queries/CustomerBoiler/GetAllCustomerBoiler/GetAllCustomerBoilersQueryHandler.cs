using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Queries
{
    public class GetAllCustomerBoilersQueryHandler : IRequestHandler<GetAllCustomerBoilersQuery, List<CustomerBoiler>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCustomerBoilersQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerBoiler>> Handle(GetAllCustomerBoilersQuery request, CancellationToken cancellationToken)
        {
            return await _context.CustomerBoilers.ToListAsync(cancellationToken);
        }
    }
}