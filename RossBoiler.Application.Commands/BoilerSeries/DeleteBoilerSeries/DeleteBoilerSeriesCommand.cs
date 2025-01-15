using MediatR;
using System.Net;

namespace RossBoiler.Application.Commands
{
    public record DeleteBoilerSeriesCommand(int Id) : IRequest<string>;
}
