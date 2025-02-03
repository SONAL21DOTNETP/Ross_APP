using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace RossBoiler.Application.Commands
{
    public class UpdateItemByIdCommandHandler : IRequestHandler<UpdateItemByIdCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public UpdateItemByIdCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(UpdateItemByIdCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

          
            var item = await _context.Items.FindAsync(new object[] { request.Id }, cancellationToken);

            if (item == null)
                throw new KeyNotFoundException($"Item with ID {request.Id} not found.");

           
            item.Name = request.Name;
            item.Price = request.Price;

            _context.Items.Update(item); 
            await _context.SaveChangesAsync(cancellationToken);

            
            return $"Item with ID {request.Id} updated successfully.";
        }
    }
}
