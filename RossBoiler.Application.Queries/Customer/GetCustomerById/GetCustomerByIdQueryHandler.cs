using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ApplicationDbContext _context;

        public GetCustomerByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(new object[] { request.CustomerID }, cancellationToken);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {request.CustomerID} not found.");
            }

            return customer;
        }
    }
}
