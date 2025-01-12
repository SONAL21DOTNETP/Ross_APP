using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateSubCategoryCommand(string Name, int CategoryID, string Description) : IRequest<int>;
}
