using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteCategoryCommand(int Id) : IRequest<string>;
}

