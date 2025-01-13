using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    
    public record GetHSNByFilterQuery(int HsnID) : IRequest<HSN>;

}