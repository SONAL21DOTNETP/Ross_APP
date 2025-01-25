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
            
            var id = _correlationIdProvider.CorrelationId;
            
            var  category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return category.ID;
        }
    }

}
