using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateAddressCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.FindAsync(new object[] { request.Id }, cancellationToken);
            if (address == null)
            {
                return $"Address with ID {request.Id} not found.";
            }

            address.CustomerId = request.CustomerId;
            address.Area = request.Area;
            address.City = request.City;
            address.Pincode = request.Pincode;
            address.State = request.State;

            await _context.SaveChangesAsync(cancellationToken);

            return $"Address with ID {request.Id} updated successfully.";
        }
    }
}