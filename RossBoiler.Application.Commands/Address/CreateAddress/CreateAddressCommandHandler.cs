using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateAddressCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");

            // Validate input fields using regex
            if (string.IsNullOrWhiteSpace(request.Area) ||
                !Regex.IsMatch(request.Area, RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Area.");
            }

            if (string.IsNullOrWhiteSpace(request.City) ||
                !Regex.IsMatch(request.City, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid City.");
            }

            if (string.IsNullOrWhiteSpace(request.Pincode) ||
                !Regex.IsMatch(request.Pincode, RegexConstants.PincodeRegex))
            {
                throw new ArgumentException("Invalid Pincode.");
            }

            if (string.IsNullOrWhiteSpace(request.State) ||
                !Regex.IsMatch(request.State, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid State.");
            }

            // Check if the customer exists before adding the address
            var customerExists = await _context.Customers.AnyAsync(c => c.Id == request.CustomerId, cancellationToken);
            if (!customerExists)
            {
                throw new ArgumentException("Customer not found.");
            }

            var address = new Address
            {
                CustomerId = request.CustomerId,
                Area = request.Area,
                City = request.City,
                Pincode = request.Pincode,
                State = request.State
            };

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync(cancellationToken);

            return address.Id;
        }
    }
}
