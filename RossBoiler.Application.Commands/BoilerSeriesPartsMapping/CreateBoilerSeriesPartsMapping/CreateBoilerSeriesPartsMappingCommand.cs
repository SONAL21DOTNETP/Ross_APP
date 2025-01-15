using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record CreateBoilerSeriesPartsMappingCommand(string Head, string Series, string Description, string DisplayAllParts) : IRequest<int>;
}
