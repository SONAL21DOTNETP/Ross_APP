using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

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
            // Log the correlationId here

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
