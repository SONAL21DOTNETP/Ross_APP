using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using System.Text.RegularExpressions;

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

            // Validate Percentage with regex
            if (!Regex.IsMatch(request.Percentage.ToString(), RegexConstants.PercentageRegex))
            {
                throw new ArgumentException("Invalid Percentage format. It should be between 0 and 100 with optional decimals.");
            }

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