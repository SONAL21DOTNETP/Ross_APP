using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteUnitCommand(int UnitID) : IRequest<string>;

}