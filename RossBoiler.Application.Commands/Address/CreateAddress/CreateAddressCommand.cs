using MediatR;
using System.Net;
namespace RossBoiler.Application.Commands
{
    public record CreateAddressCommand(int CustomerId, string Area, string City, string Pincode, string State) : IRequest<int>;

}