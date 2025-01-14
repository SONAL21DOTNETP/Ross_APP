using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record DeleteCustomerPricingCommand(int Id) : IRequest<string>;
}