using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
    public class UpdateBoilerSeriesCommandHandler : IRequestHandler<UpdateBoilerSeriesCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateBoilerSeriesCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateBoilerSeriesCommand request, CancellationToken cancellationToken)
        {
            var boilerSeries = await _context.BoilerSeries.FindAsync(new object[] { request.Id }, cancellationToken);
            if (boilerSeries == null)
            {
                return $"BoilerSeries with ID {request.Id} not found.";
            }

            boilerSeries.Head = request.Head;
            boilerSeries.SeriesCode = request.SeriesCode;
            boilerSeries.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return $"BoilerSeries with ID {request.Id} updated successfully.";
        }
    }
}
