using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllCustomerPricingQueryHandler : IRequestHandler<GetAllCustomerPricingQuery, List<CustomerPricing>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCustomerPricingQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerPricing>> Handle(GetAllCustomerPricingQuery request, CancellationToken cancellationToken)
        {
            var customerPricings = await _context.CustomerPricings.ToListAsync(cancellationToken);
            return customerPricings ?? new List<CustomerPricing>();
        }
    }
}
