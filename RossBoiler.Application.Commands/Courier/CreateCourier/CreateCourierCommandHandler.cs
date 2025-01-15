using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreateCourierCommandHandler : IRequestHandler<CreateCourierCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateCourierCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateCourierCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            // Log the correlationId here

            var courier = new Courier
            {
                BasicDetails = request.BasicDetails,
                Contacts = request.Contacts,
                Address = request.Address
            };

            _context.Couriers.Add(courier);
            await _context.SaveChangesAsync(cancellationToken);

            return courier.Id;
        }
    }
}
