using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateCustomerPricingByIdCommandHandler : IRequestHandler<UpdateCustomerPricingByIdCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public UpdateCustomerPricingByIdCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(UpdateCustomerPricingByIdCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

            var customerPricing = await _context.CustomerPricings.FirstOrDefaultAsync(c => c.ID == request.Id, cancellationToken);
            if (customerPricing == null)
            {
                return $"CustomerPricing with ID {request.Id} not found.";
            }

            customerPricing.Code = request.Code;
            customerPricing.Percentage = request.Percentage;
            customerPricing.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return $"CustomerPricing with ID {request.Id} updated successfully.";
        }
    }
}