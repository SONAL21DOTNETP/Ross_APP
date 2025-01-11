using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetItemByIdQuery(int Id) : IRequest<Item>;
}
