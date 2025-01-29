using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;


namespace RossBoiler.Application.Commands
{
    public class CreateHSNCommandHandler : IRequestHandler<CreateHSNCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        // Removed the ILogger field and the logger parameter from the constructor

        public CreateHSNCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateHSNCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var hsn = new HSN
            {
                HsnCode = request.HsnCode,
                Description = request.Description,
                Parts = new List<Parts>()
            };

            _context.HSNs.Add(hsn);
            await _context.SaveChangesAsync(cancellationToken);

            return hsn.ID;
        }
    }
}