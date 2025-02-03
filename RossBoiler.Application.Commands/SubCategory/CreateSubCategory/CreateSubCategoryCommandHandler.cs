using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateSubCategoryCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = _correlationIdProvider.CorrelationId;

            // Fetch the Category from the database
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.ID == request.CategoryID, cancellationToken);

            if (category == null)
            {
                throw new ArgumentException("Category not found.");
            }

            var subCategory = new SubCategory
            {
                Name = request.Name,
                Description = request.Description,
                CategoryId = request.CategoryID,
                Category = category // Assign the fetched category
            };

            // Add and save the entity
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync(cancellationToken);

            return subCategory.ID;
        }
    }
}
