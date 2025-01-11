using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllItemQueryHandler : IRequestHandler<GetAllItemQuery, List<Item>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllItemQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.Items.ToListAsync(cancellationToken);
        }
    }
}
