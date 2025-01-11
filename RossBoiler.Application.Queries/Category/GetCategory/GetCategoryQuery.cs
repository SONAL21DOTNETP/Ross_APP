using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetAllCategoryQuery() : IRequest<List<Category>>;
}