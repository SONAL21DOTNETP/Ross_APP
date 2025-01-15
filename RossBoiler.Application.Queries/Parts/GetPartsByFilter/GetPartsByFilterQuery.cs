using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetPartsByFilterQuery(int Id) : IRequest<Parts>;
}