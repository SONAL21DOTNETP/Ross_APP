using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Commands
{
    public class DeleteTechnicianCommandHandler : IRequestHandler<DeleteTechnicianCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTechnicianCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTechnicianCommand request, CancellationToken cancellationToken)
        {
            var technician = await _context.Technicians.FindAsync(new object[] { request.TechnicianID }, cancellationToken);

            if (technician == null)
                throw new KeyNotFoundException($"Technician with ID {request.TechnicianID} not found.");

            _context.Technicians.Remove(technician);
            await _context.SaveChangesAsync(cancellationToken);

            return request.TechnicianID;
        }
    }
}
