using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteHSNCommandHandler : IRequestHandler<DeleteHSNCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        // Removed the ILogger field and the logger parameter from the constructor

        public DeleteHSNCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(DeleteHSNCommand request, CancellationToken cancellationToken)
        {
            // Access correlationId
            var correlationId = _correlationIdProvider.CorrelationId;

            var hsn = await _context.HSNs.FindAsync(new object[] { request.HsnID }, cancellationToken);

            if (hsn == null)
                throw new KeyNotFoundException($"HSN with ID {request.HsnID} not found.");

            _context.HSNs.Remove(hsn);
            await _context.SaveChangesAsync(cancellationToken);

            return request.HsnID;
        }
    }
}