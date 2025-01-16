using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetAllTechniciansQuery() : IRequest<List<Technician>>;
}
