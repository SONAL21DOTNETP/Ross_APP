using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class CreatePartsCommandHandler : IRequestHandler<CreatePartsCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreatePartsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePartsCommand request, CancellationToken cancellationToken)
        {
            var part = new Parts
            {
                PartNumber = request.PartNumber,
                Name = request.Name,
                Description = request.Description,
          
                UnitId = request.UnitId,
                GSTId = request.GSTId,
                HSNDetailsId = request.HSNDetailsId,
                SupplyType = request.SupplyType,
                SellingPrice = request.SellingPrice,
                Weight = request.Weight,
                Dimensions = request.Dimensions,
                PackingId = request.PackingId,
                MaterialOfConstruction = request.MaterialOfConstruction
            };

            _context.Parts.Add(part);
            await _context.SaveChangesAsync(cancellationToken);

            return part.Id;
        }
    }
}