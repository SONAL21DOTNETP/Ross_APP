using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateCategoryCommand(string Name, string Description) : IRequest<int>;
}
