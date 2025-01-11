using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateSubCategoryCommand(string Name, string Description) : IRequest<int>;
}
