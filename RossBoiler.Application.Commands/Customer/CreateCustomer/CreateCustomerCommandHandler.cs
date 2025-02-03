using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateCustomerCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            
            
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
