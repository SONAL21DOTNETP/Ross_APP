using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record DeleteBoilerSeriesPartsMappingCommand(int Id) : IRequest<string>;
}
