using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetContactCentreByIdQueryHandler : IRequestHandler<GetContactCentreByIdQuery, ContactCentre>
    {
        private readonly ApplicationDbContext _context;

        public GetContactCentreByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContactCentre> Handle(GetContactCentreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.ContactCentres.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
