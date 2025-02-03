using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
namespace RossBoiler.Application.Commands
{
    public class CreateBoilerSeriesPartsMappingCommandHandler : IRequestHandler<CreateBoilerSeriesPartsMappingCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateBoilerSeriesPartsMappingCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateBoilerSeriesPartsMappingCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            //  Validate input fields
            if (string.IsNullOrWhiteSpace(request.Head) ||
                !Regex.IsMatch(request.Head, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Head.");
            }

            if (request.SeriesId <= 0)
            {
                throw new ArgumentException("Invalid Series ID.");
            }

            if (string.IsNullOrWhiteSpace(request.Description) ||
                !Regex.IsMatch(request.Description, RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Description.");
            }

            //  Check if SeriesId exists
            var existingSeries = await _context.BoilerSeries
                .FirstOrDefaultAsync(bs => bs.Id == request.SeriesId, cancellationToken);
            if (existingSeries == null)
            {
                throw new ArgumentException("Invalid Series ID. Boiler series does not exist.");
            }

            var boilerSeriesPartsMapping = new BoilerSeriesPartsMapping
            {
                Head = request.Head,
                SeriesId = request.SeriesId,
                Description = request.Description,
                DisplayAllParts = request.DisplayAllParts
            };

            _context.BoilerSeriesPartsMappings.Add(boilerSeriesPartsMapping);
            await _context.SaveChangesAsync(cancellationToken);

            return boilerSeriesPartsMapping.Id;
        }
    }
}
