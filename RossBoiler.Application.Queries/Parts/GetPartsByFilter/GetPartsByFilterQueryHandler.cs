using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetPartsByFilterQueryHandler : IRequestHandler<GetPartsByFilterQuery, Parts>
    {
        private readonly ApplicationDbContext _context;

        public GetPartsByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Parts> Handle(GetPartsByFilterQuery request, CancellationToken cancellationToken)
        {
            var item= await _context.Parts.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"Parts with ID {request.Id} not found");

            }
            return item;
        }
    }
}