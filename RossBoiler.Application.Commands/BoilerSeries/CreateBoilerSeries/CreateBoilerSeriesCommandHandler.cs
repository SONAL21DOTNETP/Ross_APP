using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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
            
            //  Validate input fields
            if (string.IsNullOrWhiteSpace(request.Head) ||
                !Regex.IsMatch(request.Head, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Boiler Series Head.");
            }

            if (request.SeriesCode <= 0)
            {
                throw new ArgumentException("Series Code must be a positive integer.");
            }

            if (string.IsNullOrWhiteSpace(request.Description) ||
                !Regex.IsMatch(request.Description, RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Boiler Series Description.");
            }

            //  Check if SeriesCode already exists
            var existingSeries = await _context.BoilerSeries
                .FirstOrDefaultAsync(bs => bs.SeriesCode == request.SeriesCode, cancellationToken);
            if (existingSeries != null)
            {
                throw new ArgumentException("Boiler Series with this SeriesCode already exists.");
            }


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
