using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;

namespace RossBoiler.Application.Commands
{
    public class UpdateItemByIdCommandHandler : IRequestHandler<UpdateItemByIdCommand, string>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public UpdateItemByIdCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider; 
        }
        public async Task<string> Handle(UpdateItemByIdCommand request, CancellationToken cancellationToken)
        {
            ////Access  correlationId
            //var id = _correlationIdProvider.CorrelationId;
            ////please write code to add this into log
            //var product = new Item
            //{
            //    Name = request.Name,
            //    Price = request.Price
            //};

            //_context.Items.Add(product);
            //await _context.SaveChangesAsync(cancellationToken);

            return "Hello world";
        }
    }

}
