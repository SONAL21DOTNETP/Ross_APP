using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand,int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public DeleteUnitCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var unit = await _context.Units.FindAsync(new object[] { request.UnitID }, cancellationToken);

            if (unit == null)
                throw new KeyNotFoundException($"Unit with ID {request.UnitID} not found.");

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync(cancellationToken);

            return request.UnitID;
        }
    }
}