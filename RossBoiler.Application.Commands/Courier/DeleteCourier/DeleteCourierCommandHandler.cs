using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteCourierCommandHandler : IRequestHandler<DeleteCourierCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteCourierCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteCourierCommand request, CancellationToken cancellationToken)
        {
            var courier = await _context.Couriers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (courier == null)
            {
                return $"Courier with ID {request.Id} not found.";
            }

            _context.Couriers.Remove(courier);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Courier with ID {request.Id} deleted successfully.";
        }
    }
}
