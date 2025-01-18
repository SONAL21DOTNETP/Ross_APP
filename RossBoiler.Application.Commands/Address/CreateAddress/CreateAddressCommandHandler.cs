using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

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
