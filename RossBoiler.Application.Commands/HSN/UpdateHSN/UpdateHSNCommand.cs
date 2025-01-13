using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateHSNCommand(int HsnID, string HsnCode, string Description) : IRequest<int>;
}