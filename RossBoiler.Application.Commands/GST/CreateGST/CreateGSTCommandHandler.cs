using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;

namespace RossBoiler.Application.Commands
{
    public class CreateGSTCommandHandler : IRequestHandler<CreateGSTCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateGSTCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateGSTCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

            var gst = new GST
            {
                Rate = request.Rate,
                Description = request.Description,
                Parts = new List<Parts>()
            };

            _context.GSTs.Add(gst);
            await _context.SaveChangesAsync(cancellationToken);

            return gst.ID;
        }
    }
}