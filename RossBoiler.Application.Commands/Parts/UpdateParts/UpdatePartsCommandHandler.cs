using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdatePartsCommandHandler : IRequestHandler<UpdatePartsCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePartsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdatePartsCommand request, CancellationToken cancellationToken)
        {
            var part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (part == null)
            {
                return $"Part with ID {request.Id} not found.";
            }

            part.PartNumber = request.PartNumber;
            part.Name = request.Name;
            part.Description = request.Description;
            part.UnitId = request.UnitId;
            part.GSTPercentage = request.GSTPercentage;
            part.HSNDetailsId = request.HSNDetailsId;
            part.SupplyType = request.SupplyType;
            part.SellingPrice = request.SellingPrice;
            part.Weight = request.Weight;
            part.Dimensions = request.Dimensions;
            part.PackingId = request.PackingId;
            part.MaterialOfConstruction = request.MaterialOfConstruction;

            await _context.SaveChangesAsync(cancellationToken);

            return $"Part with ID {request.Id} updated successfully.";
        }
    }
}