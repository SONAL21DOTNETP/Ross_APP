using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllHSNQuery() : IRequest<List<HSN>>;
}
