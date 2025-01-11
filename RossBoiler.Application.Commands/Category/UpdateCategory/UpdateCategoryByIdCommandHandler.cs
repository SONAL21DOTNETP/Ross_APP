using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;


namespace RossBoiler.Application.Commands
{
    public class UpdateCategoryByIdCommandHandler : IRequestHandler<UpdateCategoryByIdCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public UpdateCategoryByIdCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider; 
        }
        public async Task<string> Handle(UpdateCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            ////Access  correlationId
            var id = _correlationIdProvider.CorrelationId;
            ////please write code to add this into log
            ///
            // Find the item by ID
            var item = await _context.Categories.FirstOrDefaultAsync(i => i.ID == request.Id, cancellationToken);
            //if null 
            if (item == null)
            {
                return $"category with ID {request.Id} not found.";
            }
            // Update the item
            item.Name = request.Name;
            item.Description = request.Description;

            // Save changes
            await _context.SaveChangesAsync(cancellationToken);

            return $"category with ID {request.Id} updated successfully.";
        }
    }

}
