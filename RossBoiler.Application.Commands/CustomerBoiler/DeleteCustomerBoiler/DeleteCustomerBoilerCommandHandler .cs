using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteCustomerBoilerCommandHandler : IRequestHandler<DeleteCustomerBoilerCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCustomerBoilerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteCustomerBoilerCommand request, CancellationToken cancellationToken)
        {
            var customerBoiler = await _context.CustomerBoilers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (customerBoiler == null)
            {
                return $"CustomerBoiler with ID {request.Id} not found.";
            }

            _context.CustomerBoilers.Remove(customerBoiler);
            await _context.SaveChangesAsync(cancellationToken);

            return $"CustomerBoiler with ID {request.Id} deleted successfully.";
        }
    }
}
