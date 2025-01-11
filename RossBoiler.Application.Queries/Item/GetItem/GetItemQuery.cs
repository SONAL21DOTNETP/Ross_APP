using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetAllItemQuery() : IRequest<List<Item>>;
}
