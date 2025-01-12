using System.Net;
using MediatR;


namespace RossBoiler.Application.Commands
{
    public record DeleteSubCategoryCommand(int ID) : IRequest<string>;
}

