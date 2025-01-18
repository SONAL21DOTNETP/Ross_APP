using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteContactCentreCommandHandler : IRequestHandler<DeleteContactCentreCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteContactCentreCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteContactCentreCommand request, CancellationToken cancellationToken)
        {
            var contactCentre = await _context.ContactCentres.FindAsync(new object[] { request.Id }, cancellationToken);
            if (contactCentre == null)
            {
                return $"ContactCentre with ID {request.Id} not found.";
            }

            _context.ContactCentres.Remove(contactCentre);
            await _context.SaveChangesAsync(cancellationToken);

            return $"ContactCentre with ID {request.Id} deleted successfully.";
        }
    }
}
