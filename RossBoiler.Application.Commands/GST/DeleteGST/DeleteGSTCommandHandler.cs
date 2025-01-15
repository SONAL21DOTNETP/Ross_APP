using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteGSTCommandHandler : IRequestHandler<DeleteGSTCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public DeleteGSTCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(DeleteGSTCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

            var gst = await _context.GSTs.FindAsync(new object[] { request.Id }, cancellationToken);
            if (gst == null)
            {
                return $"GST with ID {request.Id} not found.";
            }

            _context.GSTs.Remove(gst);
            await _context.SaveChangesAsync(cancellationToken);

            return $"GST with ID {request.Id} has been successfully deleted.";
        }
    }

}