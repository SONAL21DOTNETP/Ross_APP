using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;


namespace RossBoiler.Application.Commands
{
    public class UpdateSubCategoryByIdCommandHandler : IRequestHandler<UpdateSubCategoryByIdCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public UpdateSubCategoryByIdCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider; 
        }
        public async Task<string> Handle(UpdateSubCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            ////Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            
            // Find the item by ID
            var item = await _context.SubCategories.FirstOrDefaultAsync(i => i.ID == request.ID, cancellationToken);
            //if null 
            if (item == null)
            {
                return $"category with ID {request.ID} not found.";
            }
            // Update the item
            item.Name = request.Name;
            item.CategoryID = request.CategoryID;
            item.Description = request.Description;

            // Save changes
            await _context.SaveChangesAsync(cancellationToken);

            return $"category with ID {request.ID} updated successfully.";
        }
    }

}
