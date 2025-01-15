using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateGSTCommand(decimal Rate, string Description) : IRequest<int>;
}