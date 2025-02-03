using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetTechnicianByIdQueryHandler : IRequestHandler<GetTechnicianByIdQuery, Technician>
    {
        private readonly ApplicationDbContext _context;

        public GetTechnicianByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Technician> Handle(GetTechnicianByIdQuery request, CancellationToken cancellationToken)
        {
            var item= await _context.Technicians.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"Technician with ID {request.Id} not found");

            }
            return item;
        }
    }
}
