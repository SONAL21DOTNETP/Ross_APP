using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreateCustomerBoilerCommandHandler : IRequestHandler<CreateCustomerBoilerCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateCustomerBoilerCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateCustomerBoilerCommand request, CancellationToken cancellationToken)
        {
            // Fetch the customer from the database using the CustomerId
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == request.CustomerId, cancellationToken);

            if (customer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            //  set the Customer navigation property
            var customerBoiler = new CustomerBoiler
            {
                CustomerId = request.CustomerId,
                BoilerHead = request.BoilerHead,
                BoilerSeries = request.BoilerSeries,
                Customer = customer 
            };

            _context.CustomerBoilers.Add(customerBoiler);
            await _context.SaveChangesAsync(cancellationToken);

            return customerBoiler.Id;
        }
    }
}
