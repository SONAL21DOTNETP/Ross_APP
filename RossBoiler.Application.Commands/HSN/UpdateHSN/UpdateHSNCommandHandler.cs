using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateHSNCommandHandler : IRequestHandler<UpdateHSNCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        // Removed the ILogger field and the logger parameter from the constructor

        public UpdateHSNCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }


        public async Task<int> Handle(UpdateHSNCommand request, CancellationToken cancellationToken)
        {
            //Access  correlationId
            var id = _correlationIdProvider.CorrelationId;

            var hsn = await _context.HSNs.FindAsync(new object[] { request.HsnID }, cancellationToken);

            if (hsn == null)
                throw new KeyNotFoundException($"HSN with ID {request.HsnID} not found.");

            hsn.HsnCode = request.HsnCode;
            hsn.Description = request.Description;

            _context.HSNs.Update(hsn);
            await _context.SaveChangesAsync(cancellationToken);

            return request.HsnID;
        }
    }
}