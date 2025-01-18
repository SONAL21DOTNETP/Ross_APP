using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateCustomerBoilerCommandHandler : IRequestHandler<UpdateCustomerBoilerCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCustomerBoilerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateCustomerBoilerCommand request, CancellationToken cancellationToken)
        {
            var customerBoiler = await _context.CustomerBoilers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (customerBoiler == null)
            {
                return $"CustomerBoiler with ID {request.Id} not found.";
            }

            customerBoiler.CustomerId = request.CustomerId;
            customerBoiler.BoilerHead = request.BoilerHead;
            customerBoiler.BoilerSeries = request.BoilerSeries;

            await _context.SaveChangesAsync(cancellationToken);

            return $"CustomerBoiler with ID {request.Id} updated successfully.";
        }
    }
}
