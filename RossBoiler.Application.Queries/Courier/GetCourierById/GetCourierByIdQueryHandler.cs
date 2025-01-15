using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetCourierByIdQueryHandler : IRequestHandler<GetCourierByIdQuery, Courier>
    {
        private readonly ApplicationDbContext _context;

        public GetCourierByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Courier> Handle(GetCourierByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Couriers.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
