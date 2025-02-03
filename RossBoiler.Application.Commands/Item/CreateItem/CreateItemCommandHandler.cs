using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreateItemCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider; 
        }
        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
          
            var id = _correlationIdProvider.CorrelationId;

            if (!Regex.IsMatch(request.Price.ToString(), RegexConstants.PriceRegex))
            {
                throw new ArgumentException("Invalid Price format. The price must be a valid number with at most two decimal places.");
            }

            var product = new Item
            {
                Name = request.Name,
                Price = request.Price
            };

            _context.Items.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.ID;
        }
    }

}
