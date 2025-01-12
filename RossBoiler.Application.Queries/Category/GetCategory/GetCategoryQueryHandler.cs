using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCategoryQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            //return await _context.Categories.ToListAsync(cancellationToken);
            var Categories = await _context.Categories.ToListAsync(cancellationToken);
            return Categories ?? new List<Category>();
        }
    }
}
