using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record CreateBoilerSeriesPartsMappingCommand(string Head, int SeriesId, string Description, string DisplayAllParts) : IRequest<int>;
}
