

using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetContactCentreByIdQuery(int Id) : IRequest<ContactCentre>;
}