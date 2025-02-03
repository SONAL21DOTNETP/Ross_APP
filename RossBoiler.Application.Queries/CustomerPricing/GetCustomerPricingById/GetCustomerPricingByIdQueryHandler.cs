using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetCustomerPricingByIdQueryHandler : IRequestHandler<GetCustomerPricingByIdQuery, CustomerPricing>
    {
        private readonly ApplicationDbContext _context;

        public GetCustomerPricingByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerPricing> Handle(GetCustomerPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var item= await _context.CustomerPricings.FirstOrDefaultAsync(c => c.ID == request.Id, cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"CustomerPricing with ID {request.Id} not found");

            }
            return item;
        }
    }
}