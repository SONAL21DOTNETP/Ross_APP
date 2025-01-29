using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    //public class CreatePartsCommandHandler : IRequestHandler<CreatePartsCommand, int>
    //{
    //    private readonly ApplicationDbContext _context;

    //    public CreatePartsCommandHandler(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<int> Handle(CreatePartsCommand request, CancellationToken cancellationToken)
    //    {
    //        var part = new Parts
    //        {
    //            PartNumber = request.PartNumber,
    //            Name = request.Name,
    //            Description = request.Description,

    //            UnitId = request.UnitId,
    //            GSTId = request.GSTId,
    //            HSNDetailsId = request.HSNDetailsId,
    //            SupplyType = request.SupplyType,
    //            SellingPrice = request.SellingPrice,
    //            Weight = request.Weight,
    //            Dimensions = request.Dimensions,
    //            PackingId = (int)request.Id,
    //            MaterialOfConstruction = request.MaterialOfConstruction
    //        };

    //        _context.Parts.Add(part);
    //        await _context.SaveChangesAsync(cancellationToken);

    //        return part.Id;
    //    }
    //}
    public class CreatePartsCommandHandler : IRequestHandler<CreatePartsCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreatePartsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePartsCommand request, CancellationToken cancellationToken)
        {
            // Fetch existing related entities from the database
            var unit = await _context.Units.FirstOrDefaultAsync(u => u.ID == request.UnitId, cancellationToken);
            var gst = await _context.GSTs.FirstOrDefaultAsync(g => g.ID == request.GSTId, cancellationToken);
            var hsn = await _context.HSNs.FirstOrDefaultAsync(h => h.ID == request.HSNDetailsId, cancellationToken);
            var packing = await _context.Packings.FirstOrDefaultAsync(p => p.ID == request.Id, cancellationToken);


            // Ensure that required entities are fetched
            if (unit == null || gst == null || hsn == null || packing == null)
            {
                throw new Exception("One or more related entities are missing.");
            }

            var part = new Parts
            {
                PartNumber = request.PartNumber,
                Name = request.Name,
                Description = request.Description,
                SupplyType = request.SupplyType,
                SellingPrice = request.SellingPrice,
                Weight = request.Weight,
                Dimensions = request.Dimensions,
                MaterialOfConstruction = request.MaterialOfConstruction,
                CreatedDate = DateTime.Now,
                Unit = unit,  
                GST = gst,    
                HSN = hsn,    
                Packing = packing  
            };

            _context.Parts.Add(part);
            await _context.SaveChangesAsync(cancellationToken);

            return part.Id;
        }
    }

}