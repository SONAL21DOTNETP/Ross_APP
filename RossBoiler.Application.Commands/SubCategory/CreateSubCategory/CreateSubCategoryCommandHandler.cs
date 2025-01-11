using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;

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
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            //please write code to add this into log
            // Create the Item entity
            var subcategory = new SubCategory
            {
                Name = request.Name,
                Description = request.Description
            };

            // Add and save the entity
            _context.SubCategories.Add(subcategory);
            await _context.SaveChangesAsync(cancellationToken);

            return subcategory.ID;
        }
    }

}
