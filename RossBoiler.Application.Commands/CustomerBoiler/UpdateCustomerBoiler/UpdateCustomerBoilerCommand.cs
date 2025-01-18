using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
    public record UpdateCustomerBoilerCommand(int Id, int CustomerId, string BoilerHead, string BoilerSeries) : IRequest<string>;


}