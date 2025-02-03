using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    
    public class CreatePartsCommandHandler : IRequestHandler<CreatePartsCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreatePartsCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreatePartsCommand request, CancellationToken cancellationToken)
        {

            // Validate input fields using regex constants
            if (!Regex.IsMatch(request.Name, RegexConstants.AlphanumericRegex))
                throw new Exception("Invalid Name.");

            if (!Regex.IsMatch(request.SellingPrice.ToString(), RegexConstants.PriceRegex))
                throw new Exception("Invalid Selling Price.");

            if (!request.Weight.HasValue ||
                !Regex.IsMatch(request.Weight.Value.ToString(), RegexConstants.PriceRegex))
            {
                throw new ArgumentException("Invalid Weight.");
            }

            if (string.IsNullOrWhiteSpace(request.Dimensions) ||
                !Regex.IsMatch(request.Dimensions, RegexConstants.DimensionsRegex))
            {
                throw new ArgumentException("Invalid Dimensions.");
            }

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