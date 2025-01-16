using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public record GetTechnicianByIdQuery(int Id) : IRequest<Technician>;
}
