using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetAllGSTQuery() : IRequest<List<GST>>;
}