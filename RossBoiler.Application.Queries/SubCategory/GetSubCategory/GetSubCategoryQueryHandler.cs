using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQuery, List<SubCategory>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllSubCategoryQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategory>> Handle(GetAllSubCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _context.SubCategories.ToListAsync(cancellationToken);
        }
    }
}
