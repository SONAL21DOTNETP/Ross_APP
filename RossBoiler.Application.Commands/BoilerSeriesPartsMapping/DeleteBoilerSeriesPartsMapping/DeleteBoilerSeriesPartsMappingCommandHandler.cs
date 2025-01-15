using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteBoilerSeriesPartsMappingCommandHandler : IRequestHandler<DeleteBoilerSeriesPartsMappingCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBoilerSeriesPartsMappingCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteBoilerSeriesPartsMappingCommand request, CancellationToken cancellationToken)
        {
            var partsMapping = await _context.BoilerSeriesPartsMappings
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (partsMapping == null)
            {
                return $"BoilerSeriesPartsMapping with ID {request.Id} not found.";
            }

            _context.BoilerSeriesPartsMappings.Remove(partsMapping);
            await _context.SaveChangesAsync(cancellationToken);

            return $"BoilerSeriesPartsMapping with ID {request.Id} deleted successfully.";
        }
    }
}
