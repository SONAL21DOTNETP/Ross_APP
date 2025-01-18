using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdatePartsCommand(
        int Id,
        int PartNumber,
        string Name,
        string? Description,
        
        int UnitId,
        int  GSTId,
        int HSNDetailsId,
        string SupplyType,
        decimal SellingPrice,
        decimal? Weight,
        string? Dimensions,
        int? PackingId,
        string? MaterialOfConstruction) : IRequest<string>;
}