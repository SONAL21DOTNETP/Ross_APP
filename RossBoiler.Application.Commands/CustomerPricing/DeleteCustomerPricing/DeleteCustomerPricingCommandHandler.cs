using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteCustomerPricingCommandHandler : IRequestHandler<DeleteCustomerPricingCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public DeleteCustomerPricingCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(DeleteCustomerPricingCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

            var customerPricing = await _context.CustomerPricings.FindAsync(new object[] { request.Id }, cancellationToken);
            if (customerPricing == null)
            {
                return $"CustomerPricing with ID {request.Id} not found.";
            }

            _context.CustomerPricings.Remove(customerPricing);
            await _context.SaveChangesAsync(cancellationToken);

            return $"CustomerPricing with ID {request.Id} has been successfully deleted.";
        }
    }

}