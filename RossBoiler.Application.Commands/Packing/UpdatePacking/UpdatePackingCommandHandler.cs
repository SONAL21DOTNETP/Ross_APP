using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdatePackingCommandHandler : IRequestHandler<UpdatePackingCommand,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public UpdatePackingCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(UpdatePackingCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var packing = await _context.Packings.FindAsync(new object[] { request.PackingID }, cancellationToken);

            if (packing == null)
                throw new KeyNotFoundException($"Packing with ID {request.PackingID} not found.");

            packing.Name = request.Name;
            packing.UsedFor = request.UsedFor;
            packing.Description = request.Description;

            _context.Packings.Update(packing);
            await _context.SaveChangesAsync(cancellationToken);

            return request.PackingID;
        }
    }
}