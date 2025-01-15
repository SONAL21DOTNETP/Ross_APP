using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateBoilerCommandHandler : IRequestHandler<UpdateBoilerCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateBoilerCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateBoilerCommand request, CancellationToken cancellationToken)
        {
            var boiler = await _context.Boilers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boiler == null)
            {
                return $"Boiler with ID {request.Id} not found.";
            }

            boiler.Head = request.Head;
            boiler.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return $"Boiler with ID {request.Id} updated successfully.";
        }
    }
}
