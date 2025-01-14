using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries { 
    public class GetAllHSNQueryHandler : IRequestHandler<GetAllHSNQuery, List<HSN>>
    {
        private readonly ApplicationDbContext _context;
        public GetAllHSNQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HSN>> Handle(GetAllHSNQuery request, CancellationToken cancellationToken)
        {
            return await _context.HSNs.ToListAsync(cancellationToken);
        }
    }
}