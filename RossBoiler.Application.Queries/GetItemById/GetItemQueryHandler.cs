using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery,Item>
    {
        private readonly ApplicationDbContext _context;

        public GetItemByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Items.FirstOrDefaultAsync(x=>x.ID==request.Id,cancellationToken);
        }
    }
}
