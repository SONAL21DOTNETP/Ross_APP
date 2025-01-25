using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreatePackingCommandHandler : IRequestHandler<CreatePackingCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreatePackingCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreatePackingCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var packing = new Packing
            {
                Name = request.Name,
                UsedFor = request.UsedFor,
                Description = request.Description,
                Parts = new List<Parts>()
            };

            _context.Packings.Add(packing);
            await _context.SaveChangesAsync(cancellationToken);

            return packing.ID;
        }
    }

}