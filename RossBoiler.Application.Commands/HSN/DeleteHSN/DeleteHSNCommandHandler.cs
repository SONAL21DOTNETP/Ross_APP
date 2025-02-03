using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace RossBoiler.Application.Commands
{
    public class DeleteHSNCommandHandler : IRequestHandler<DeleteHSNCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public DeleteHSNCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(DeleteHSNCommand request, CancellationToken cancellationToken)
        {
           
            var correlationId = _correlationIdProvider.CorrelationId;

            var hsn = await _context.HSNs.FindAsync(new object[] { request.HsnID }, cancellationToken);

            if (hsn == null)
                throw new KeyNotFoundException($"HSN with ID {request.HsnID} not found.");

            _context.HSNs.Remove(hsn);
            await _context.SaveChangesAsync(cancellationToken);

            return $"HSN with ID {request.HsnID} deleted successfully.";
        }
    }
}
