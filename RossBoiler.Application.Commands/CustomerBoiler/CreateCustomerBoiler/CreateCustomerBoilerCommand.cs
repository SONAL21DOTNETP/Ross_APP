

using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record CreateCustomerBoilerCommand(int CustomerId, string BoilerHead, string BoilerSeries) : IRequest<int>;

}