using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
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
            // Log the correlationId here

            var boilerSeriesPartsMapping = new BoilerSeriesPartsMapping
            {
                Head = request.Head,
                Series = request.Series,
                Description = request.Description,
                DisplayAllParts = request.DisplayAllParts
            };

            _context.BoilerSeriesPartsMappings.Add(boilerSeriesPartsMapping);
            await _context.SaveChangesAsync(cancellationToken);

            return boilerSeriesPartsMapping.Id;
        }
    }
}
