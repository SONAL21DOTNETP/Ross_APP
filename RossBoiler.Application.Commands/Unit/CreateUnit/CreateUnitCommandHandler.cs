using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreateUnitCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var unit = new Unit
            {
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                Parts = new List<Parts>()

            };

            _context.Units.Add(unit);
            await _context.SaveChangesAsync(cancellationToken);

            return unit.ID;
        }
    }
}