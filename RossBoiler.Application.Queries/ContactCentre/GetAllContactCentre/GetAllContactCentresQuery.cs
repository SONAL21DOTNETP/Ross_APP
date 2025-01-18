
using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllContactCentresQuery() : IRequest<List<ContactCentre>>;
}