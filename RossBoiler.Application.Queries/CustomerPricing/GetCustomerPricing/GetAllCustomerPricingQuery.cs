using RossBoiler.Application.Models;
using MediatR;

namespace RossBoiler.Application.Queries
{
    public record GetAllCustomerPricingQuery() : IRequest<List<CustomerPricing>>;

}