using MediatR;
using System.Net;

namespace RossBoiler.Application.Commands
{
    public record CreateBoilerSeriesCommand(string Head, int SeriesCode, string Description) : IRequest<int>;
}
