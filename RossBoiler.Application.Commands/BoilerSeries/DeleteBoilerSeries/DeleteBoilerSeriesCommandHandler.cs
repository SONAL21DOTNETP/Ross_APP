using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class DeleteBoilerSeriesCommandHandler : IRequestHandler<DeleteBoilerSeriesCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public DeleteBoilerSeriesCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteBoilerSeriesCommand request, CancellationToken cancellationToken)
        {
            var boilerSeries = await _context.BoilerSeries.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boilerSeries == null)
            {
                return $"BoilerSeries with ID {request.Id} not found.";
            }

            _context.BoilerSeries.Remove(boilerSeries);
            await _context.SaveChangesAsync(cancellationToken);

            return $"BoilerSeries with ID {request.Id} deleted successfully.";
        }
    }
}
