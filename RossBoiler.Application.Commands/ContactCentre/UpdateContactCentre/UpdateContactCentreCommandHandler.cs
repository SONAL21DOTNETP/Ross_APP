using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateContactCentreCommandHandler : IRequestHandler<UpdateContactCentreCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateContactCentreCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateContactCentreCommand request, CancellationToken cancellationToken)
        {
            var contactCentre = await _context.ContactCentres.FindAsync(new object[] { request.Id }, cancellationToken);
            if (contactCentre == null)
            {
                return $"ContactCentre with ID {request.Id} not found.";
            }

            contactCentre.CustomerId = request.CustomerId;
            contactCentre.POC = request.POC;
            contactCentre.PhoneNumber1 = request.PhoneNumber1;
            contactCentre.PhoneNumber2 = request.PhoneNumber2;
            contactCentre.PhoneNumber3 = request.PhoneNumber3;

            await _context.SaveChangesAsync(cancellationToken);

            return $"ContactCentre with ID {request.Id} updated successfully.";
        }
    }
}