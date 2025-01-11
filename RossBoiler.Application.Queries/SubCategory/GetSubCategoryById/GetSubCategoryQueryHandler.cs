using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, SubCategory>
    {
        private readonly ApplicationDbContext _context;

        public GetSubCategoryByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SubCategory> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.ID == request.ID, cancellationToken);

            if (subCategory == null)
            {
                
                return null;  
            }

            return subCategory;
        }
    }
}
