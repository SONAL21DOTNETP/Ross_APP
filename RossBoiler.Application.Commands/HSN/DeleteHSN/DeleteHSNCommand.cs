using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteHSNCommand(int HsnID) : IRequest<string>;
}
