using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateGSTByIdCommandHandler : IRequestHandler<UpdateGSTByIdCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public UpdateGSTByIdCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(UpdateGSTByIdCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;

            var gst = await _context.GSTs.FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);
            if (gst == null)
            {
                return $"GST with ID {request.Id} not found.";
            }

            gst.Rate = request.Rate;
            gst.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return $"GST with ID {request.Id} updated successfully.";
        }
    }

}