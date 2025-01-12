using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;

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
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            //please write code to add this into log
            // Create the Item entity
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            // Add and save the entity
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return category.ID;
        }
    }

}
