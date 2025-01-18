
using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAddressByIdQuery(int Id) : IRequest<Address>;
}