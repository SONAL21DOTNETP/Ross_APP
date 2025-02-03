using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    public class CreateBoilerCommandHandler : IRequestHandler<CreateBoilerCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CreateBoilerCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateBoilerCommand request, CancellationToken cancellationToken)
        {
            var correlationId = _correlationIdProvider.CorrelationId;
            

            // Validate input fields
            if (string.IsNullOrWhiteSpace(request.Head) ||
                !Regex.IsMatch(request.Head, RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Boiler Head.");
            }

            if (string.IsNullOrWhiteSpace(request.Description) ||
                !Regex.IsMatch(request.Description, RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Boiler Description.");
            }

            // check if the Boiler with the same Head already exists
            var existingBoiler = await _context.Boilers
                .FirstOrDefaultAsync(b => b.Head == request.Head, cancellationToken);
            if (existingBoiler != null)
            {
                throw new ArgumentException("Boiler with this Head already exists.");
            }

            var boiler = new Boiler
            {
                Head = request.Head,
                Description = request.Description
            };

            _context.Boilers.Add(boiler);
            await _context.SaveChangesAsync(cancellationToken);

            return boiler.Id;
        }
    }
}
