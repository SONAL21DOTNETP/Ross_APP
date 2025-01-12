using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;


namespace RossBoiler.Application.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        // Removed the ILogger field and the logger parameter from the constructor

        public DeleteCategoryCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Access correlationId
            var correlationId = _correlationIdProvider.CorrelationId;

            // Find the category by ID
            var category = await _context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);
            if (category == null)
            {
                return $"Category with ID {request.Id} not found.";
            }

            // Remove the category
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Category with ID {request.Id} has been successfully deleted.";
        }
    }
}
