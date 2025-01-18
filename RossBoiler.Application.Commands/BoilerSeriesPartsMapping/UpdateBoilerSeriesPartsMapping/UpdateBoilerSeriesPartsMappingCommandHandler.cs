using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateBoilerSeriesPartsMappingCommandHandler : IRequestHandler<UpdateBoilerSeriesPartsMappingCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateBoilerSeriesPartsMappingCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateBoilerSeriesPartsMappingCommand request, CancellationToken cancellationToken)
        {
            var partsMapping = await _context.BoilerSeriesPartsMappings
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (partsMapping == null)
            {
                return $"BoilerSeriesPartsMapping with ID {request.Id} not found.";
            }

            partsMapping.Head = request.Head;
            partsMapping.SeriesId = request.SeriesId;
            partsMapping.Description = request.Description;
            partsMapping.DisplayAllParts = request.DisplayAllParts;

            await _context.SaveChangesAsync(cancellationToken);

            return $"BoilerSeriesPartsMapping with ID {request.Id} updated successfully.";
        }
    }
}
