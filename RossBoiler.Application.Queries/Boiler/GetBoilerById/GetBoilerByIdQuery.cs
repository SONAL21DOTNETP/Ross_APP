using MediatR;
using RossBoiler.Application.Models;


namespace RossBoiler.Application.Queries
{
    public record GetBoilerByIdQuery(int Id) : IRequest<Boiler>;
}
