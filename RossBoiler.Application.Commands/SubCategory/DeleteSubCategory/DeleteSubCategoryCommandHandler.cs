using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;


namespace RossBoiler.Application.Commands
{
    public class DeleteSubCategoryCommandHandler : IRequestHandler<DeleteSubCategoryCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public DeleteSubCategoryCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            // Access correlationId
            var correlationId = _correlationIdProvider.CorrelationId;

            // Find the subcategory by ID
            var subCategory = await _context.SubCategories.FindAsync(new object[] { request.ID }, cancellationToken);

            if (subCategory == null)
            {
                return $"SubCategory with ID {request.ID} not found.";
            }

            // Remove the subcategory
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync(cancellationToken);

            return $"SubCategory with ID {request.ID} has been successfully deleted.";
        }
    }
}
