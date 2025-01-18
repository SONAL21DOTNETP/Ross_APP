
using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
	public record DeleteAddressCommand(int Id) : IRequest<string>;
}