using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
namespace RossBoiler.Application.Commands
{
    public class CreateBoilerSeriesCommandHandler : IRequestHandler<CreateBoilerSeriesCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateBoilerSeriesCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateBoilerSeriesCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            // Log the correlationId here

            var boilerSeries = new BoilerSeries
            {
                Head = request.Head,
                SeriesCode = request.SeriesCode,
                Description = request.Description
            };

            _context.BoilerSeries.Add(boilerSeries);
            await _context.SaveChangesAsync(cancellationToken);

            return boilerSeries.Id;
        }
    }
}
