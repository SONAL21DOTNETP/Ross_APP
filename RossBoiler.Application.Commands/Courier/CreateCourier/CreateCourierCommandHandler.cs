using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

            //  Validate BasicDetails (Assuming it's a name or company name)
            if (!Regex.IsMatch(request.BasicDetails, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Basic Details. Only alphabets are allowed.");
            }

            //  Validate Address
            if (!Regex.IsMatch(request.Address, RegexConstants.AddressRegex))
            {
                throw new ArgumentException("Invalid Address format.");
            }

            //  Validate Contact Numbers (Assuming multiple numbers are separated by commas)
            var contactNumbers = request.Contacts.Split(',');
            foreach (var number in contactNumbers)
            {
                if (!Regex.IsMatch(number.Trim(), RegexConstants.PhoneNumberRegex))
                {
                    throw new ArgumentException($"Invalid phone number format: {number}");
                }
            }

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
