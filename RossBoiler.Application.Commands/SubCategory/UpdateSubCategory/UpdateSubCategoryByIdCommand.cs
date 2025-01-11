using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateSubCategoryByIdCommand(int ID, string Name, string Description) : IRequest<string>;
}
