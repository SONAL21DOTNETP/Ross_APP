
using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateAddressCommand(int Id, int CustomerId, string Area, string City, string Pincode, string State) : IRequest<string>;

}