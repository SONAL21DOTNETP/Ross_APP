using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    public class CreateContactCentreCommandHandler : IRequestHandler<CreateContactCentreCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreateContactCentreCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateContactCentreCommand request, CancellationToken cancellationToken)
        {
            var id = _correlationIdProvider.CorrelationId;

            var customer = await _context.Customers.FindAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {request.CustomerId} not found.");
            }
            // Validate POC Name (Only letters and spaces allowed)
            if (!Regex.IsMatch(request.POC, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid POC Name. Only alphabets allowed.");
            }

            // Validate Phone Numbers (Must match PhoneNumberRegex)
            if (!Regex.IsMatch(request.PhoneNumber1, RegexConstants.PhoneNumberRegex) ||
                !Regex.IsMatch(request.PhoneNumber2, RegexConstants.PhoneNumberRegex) ||
                !Regex.IsMatch(request.PhoneNumber3, RegexConstants.PhoneNumberRegex))
            {
                throw new ArgumentException("Invalid phone number format.");
            }

            // ✅Ensure Phone Numbers are Unique per Customer
            var existingNumbers = await _context.ContactCentres
                .Where(c => c.CustomerId == request.CustomerId &&
                            (c.PhoneNumber1 == request.PhoneNumber1 ||
                             c.PhoneNumber2 == request.PhoneNumber2 ||
                             c.PhoneNumber3 == request.PhoneNumber3))
                .ToListAsync(cancellationToken);

            if (existingNumbers.Any())
            {
                throw new Exception("Phone numbers must be unique for the same customer.");
            }

            var contactCentre = new ContactCentre
            {
                CustomerId = request.CustomerId,
                POC = request.POC,
                PhoneNumber1 = request.PhoneNumber1,
                PhoneNumber2 = request.PhoneNumber2,
                PhoneNumber3 = request.PhoneNumber3,
                Customer = customer,
            };

            _context.ContactCentres.Add(contactCentre);
            await _context.SaveChangesAsync(cancellationToken);

            return contactCentre.Id;
        }
    }
}
