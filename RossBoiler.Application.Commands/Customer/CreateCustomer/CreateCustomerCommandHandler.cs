using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateCustomerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                OrgName = request.OrgName,
                Description = request.Description,
                Addresses = new List<Address>(),
                ContactCentres = new List<ContactCentre>(),  
                CustomerBoilers = new List<CustomerBoiler>()
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
