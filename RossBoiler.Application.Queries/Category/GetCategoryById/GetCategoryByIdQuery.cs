using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetCategoryByIdQuery(int Id) : IRequest<Category>;
}
