using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public UpdateUnitCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            // Access correlationId
            var id = _correlationIdProvider.CorrelationId;

            var unit = await _context.Units.FindAsync(new object[] { request.UnitID }, cancellationToken);

            if (unit == null)
                throw new KeyNotFoundException($"Unit with ID {request.UnitID} not found.");

            unit.Name = request.Name;
            unit.Code = request.Code;
            unit.Description = request.Description;

            _context.Units.Update(unit);
            await _context.SaveChangesAsync(cancellationToken);

           
            return $"Unit with ID {request.UnitID} updated successfully.";
        }
    }
}
