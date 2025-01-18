using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreateContactCentreCommandHandler : IRequestHandler<CreateContactCentreCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateContactCentreCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContactCentreCommand request, CancellationToken cancellationToken)
        {
            var contactCentre = new ContactCentre
            {
                CustomerId = request.CustomerId,
                POC = request.POC,
                PhoneNumber1 = request.PhoneNumber1,
                PhoneNumber2 = request.PhoneNumber2,
                PhoneNumber3 = request.PhoneNumber3
            };

            _context.ContactCentres.Add(contactCentre);
            await _context.SaveChangesAsync(cancellationToken);

            return contactCentre.Id;
        }
    }
}
