using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetBoilerByIdQueryHandler : IRequestHandler<GetBoilerByIdQuery, Boiler>
    {
        private readonly ApplicationDbContext _context;

        public GetBoilerByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Boiler> Handle(GetBoilerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Boilers.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}