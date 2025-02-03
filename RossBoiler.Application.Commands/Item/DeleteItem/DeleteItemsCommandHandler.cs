using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace RossBoiler.Application.Commands
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public DeleteItemCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<string> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
           
            var correlationId = _correlationIdProvider.CorrelationId;

            var item = await _context.Items.FindAsync(new object[] { request.ID }, cancellationToken);

            

            if (item == null)
                throw new KeyNotFoundException($"Item with ID {request.ID} not found.");

            _context.Items.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

           
            return $"Item with ID {request.ID} Delete successfully.";
        }
    }
}
