using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateCustomerPricingCommand(int Code, decimal Percentage, string Description) : IRequest<int>;
}