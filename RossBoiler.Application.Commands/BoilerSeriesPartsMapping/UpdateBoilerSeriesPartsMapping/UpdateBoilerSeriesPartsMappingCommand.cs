using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record UpdateBoilerSeriesPartsMappingCommand(
        int Id,
        string Head,
        string Series,
        string Description,
        string DisplayAllParts
    ) : IRequest<string>;
}
