using System.Net;
using MediatR;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Commands
{
    public record DeleteHSNCommand(int HsnID) : IRequest<int>;
}