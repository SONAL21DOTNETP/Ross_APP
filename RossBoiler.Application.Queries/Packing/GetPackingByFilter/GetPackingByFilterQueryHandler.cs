using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetPackingByFilterQueryHandler : IRequestHandler<GetPackingByFilterQuery, Packing>
    {
        private readonly ApplicationDbContext _context;
        public GetPackingByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Packing> Handle(GetPackingByFilterQuery request, CancellationToken cancellationToken)
        {

            var item= await _context.Packings
                .FindAsync(new object[] { request.PackingID }, cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"Packing with ID {request.PackingID} not found");

            }
            return item;

        }
    }
}