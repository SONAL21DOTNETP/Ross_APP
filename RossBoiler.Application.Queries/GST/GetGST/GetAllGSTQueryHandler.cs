using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllGSTQueryHandler : IRequestHandler<GetAllGSTQuery, List<GST>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllGSTQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GST>> Handle(GetAllGSTQuery request, CancellationToken cancellationToken)
        {
            var gstRecords = await _context.GSTs.ToListAsync(cancellationToken);
            return gstRecords ?? new List<GST>();
        }
    }
}
