using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteBoilerCommandHandler : IRequestHandler<DeleteBoilerCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBoilerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteBoilerCommand request, CancellationToken cancellationToken)
        {
            var boiler = await _context.Boilers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boiler == null)
            {
                return $"Boiler with ID {request.Id} not found.";
            }

            _context.Boilers.Remove(boiler);
            await _context.SaveChangesAsync(cancellationToken);

            return $"Boiler with ID {request.Id} deleted successfully.";
        }
    }
}
