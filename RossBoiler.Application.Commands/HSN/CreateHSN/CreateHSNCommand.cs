using System.Net;
using MediatR;


namespace RossBoiler.Application.Commands
{
    public record CreateHSNCommand(string HsnCode, string Description) : IRequest<int>;
}