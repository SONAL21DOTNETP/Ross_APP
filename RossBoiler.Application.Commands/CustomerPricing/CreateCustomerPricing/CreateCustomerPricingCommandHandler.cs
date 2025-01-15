using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;

namespace RossBoiler.Application.Commands
{
    public class CreateCustomerPricingCommandHandler : IRequestHandler<CreateCustomerPricingCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateCustomerPricingCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateCustomerPricingCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

            var customerPricing = new CustomerPricing
            {
                Code = request.Code,
                Percentage = request.Percentage,
                Description = request.Description
            };

            _context.CustomerPricings.Add(customerPricing);
            await _context.SaveChangesAsync(cancellationToken);

            return customerPricing.ID;
        }
    }
}