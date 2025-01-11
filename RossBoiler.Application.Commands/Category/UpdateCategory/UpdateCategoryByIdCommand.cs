using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateCategoryByIdCommand(int Id, string Name, string Description) : IRequest<string>;
}
