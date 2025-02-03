using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ApplicationDbContext _context;

        public GetCategoryByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var item =await _context.Categories.FirstOrDefaultAsync(x=>x.ID==request.Id,cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"Category with ID {request.Id} not found");

            }
            return item;
        }
    }
}