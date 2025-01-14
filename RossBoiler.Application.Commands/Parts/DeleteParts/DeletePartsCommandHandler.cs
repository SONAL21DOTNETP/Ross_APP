using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeletePartsCommandHandler : IRequestHandler<DeletePartsCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeletePartsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeletePartsCommand request, CancellationToken cancellationToken)
        {
            var part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (part == null)
            {
                return $"Part with ID {request.Id} not found.";
            }

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Part with ID {request.Id} deleted successfully.";
        }
    }
}