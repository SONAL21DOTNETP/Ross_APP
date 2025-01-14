using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeletePackingCommandHandler : IRequestHandler<DeletePackingCommand,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public DeletePackingCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(DeletePackingCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var packing = await _context.Packings.FindAsync(new object[] { request.PackingID }, cancellationToken);

            if (packing == null)
                throw new KeyNotFoundException($"Packing with ID {request.PackingID} not found.");

            _context.Packings.Remove(packing);
            await _context.SaveChangesAsync(cancellationToken);

            return request.PackingID;
        }
    }
}