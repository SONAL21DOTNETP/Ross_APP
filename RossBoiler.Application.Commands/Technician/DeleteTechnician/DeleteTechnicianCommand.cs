using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteTechnicianCommand(int TechnicianID) : IRequest<int>;
}
