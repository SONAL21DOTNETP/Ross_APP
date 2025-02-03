using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;


namespace RossBoiler.Application.Queries
{
    public class GetHSNByFilterQueryHandler : IRequestHandler<GetHSNByFilterQuery, HSN>
    {
        private readonly ApplicationDbContext _context;
        public GetHSNByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HSN> Handle(GetHSNByFilterQuery request, CancellationToken cancellationToken)
        {
            var item= await _context.HSNs
                .FindAsync(new object[] { request.HsnID }, cancellationToken);

            if (item == null)
            {

                throw new KeyNotFoundException($"HSN with ID {request.HsnID} not found");

            }
            return item;

        }


    }
}