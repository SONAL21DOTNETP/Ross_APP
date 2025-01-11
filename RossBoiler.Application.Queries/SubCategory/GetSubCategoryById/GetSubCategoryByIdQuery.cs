using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetSubCategoryByIdQuery(int ID) : IRequest<SubCategory>;
}
