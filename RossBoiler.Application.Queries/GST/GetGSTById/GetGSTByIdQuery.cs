using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetGSTByIdQuery(int Id) : IRequest<GST>;
}
