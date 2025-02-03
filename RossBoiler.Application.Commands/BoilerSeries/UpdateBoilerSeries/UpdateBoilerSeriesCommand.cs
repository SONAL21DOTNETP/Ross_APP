using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record UpdateBoilerSeriesCommand(int Id, string Head, int SeriesCode, string Description) : IRequest<string>;
}
