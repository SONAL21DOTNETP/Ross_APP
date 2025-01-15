using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateCourierCommandHandler : IRequestHandler<UpdateCourierCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCourierCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateCourierCommand request, CancellationToken cancellationToken)
        {
            var courier = await _context.Couriers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (courier == null)
            {
                return $"Courier with ID {request.Id} not found.";
            }

            courier.BasicDetails = request.BasicDetails;
            courier.Contacts = request.Contacts;
            courier.Address = request.Address;

            await _context.SaveChangesAsync(cancellationToken);

            return $"Courier with ID {request.Id} updated successfully.";
        }
    }
}
