using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCustomerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(new object[] { request.CustomerID }, cancellationToken);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {request.CustomerID} not found.");
            }

            customer.OrgName = request.OrgName;
            customer.Description = request.Description;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(cancellationToken);

            
            return $"Customer with ID {customer.Id} Update successfully.";
        }
    }
}
