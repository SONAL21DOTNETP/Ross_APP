using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateCustomerPricingByIdCommand(int Id, int Code, decimal Percentage, string Description) : IRequest<string>;
}