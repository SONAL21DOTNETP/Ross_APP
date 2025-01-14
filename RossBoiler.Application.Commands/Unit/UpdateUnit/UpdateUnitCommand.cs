using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateUnitCommand(int UnitID, string Code, string Name, string Description) : IRequest<int>;
}
