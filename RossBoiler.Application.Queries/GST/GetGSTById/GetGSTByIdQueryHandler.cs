using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetGSTByIdQueryHandler : IRequestHandler<GetGSTByIdQuery, GST>
    {
        private readonly ApplicationDbContext _context;

        public GetGSTByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GST> Handle(GetGSTByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GSTs.FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);
        }
    }
}