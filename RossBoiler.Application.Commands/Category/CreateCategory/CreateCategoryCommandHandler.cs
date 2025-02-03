using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreateCategoryCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            
            var id = _correlationIdProvider.CorrelationId;

            //  Validate input fields
            if (string.IsNullOrWhiteSpace(request.Name) ||
                !Regex.IsMatch(request.Name, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Category Name.");
            }

            if (string.IsNullOrWhiteSpace(request.Description) ||
                !Regex.IsMatch(request.Description, RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Description.");
            }

            //  Check if Category already exists
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == request.Name, cancellationToken);
            if (existingCategory != null)
            {
                throw new ArgumentException("Category already exists.");
            }

            var  category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                SubCategories = new List<SubCategory>()
            };

            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return category.ID;
        }
    }

}
