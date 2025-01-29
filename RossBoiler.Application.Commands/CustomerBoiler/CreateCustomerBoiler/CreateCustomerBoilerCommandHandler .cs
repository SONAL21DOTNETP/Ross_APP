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
        private Customer customer;

        public CreateCustomerBoilerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCustomerBoilerCommand request, CancellationToken cancellationToken)
        {
            var customerBoiler = new CustomerBoiler
            {
                Customer = customer,
                CustomerId = request.CustomerId,
                BoilerHead = request.BoilerHead,
                BoilerSeries = request.BoilerSeries
            };

            _context.CustomerBoilers.Add(customerBoiler);
            await _context.SaveChangesAsync(cancellationToken);

            return customerBoiler.Id;
        }
    }
}