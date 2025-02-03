using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetBoilerSeriesByIdQueryHandler : IRequestHandler<GetBoilerSeriesByIdQuery, BoilerSeries>
    {
        private readonly ApplicationDbContext _context;

        public GetBoilerSeriesByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BoilerSeries> Handle(GetBoilerSeriesByIdQuery request, CancellationToken cancellationToken)
        {
            var item= await _context.BoilerSeries.FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
            {
               
                throw new KeyNotFoundException($"BoilerSeries with ID {request.Id} not found");

            }
            return item;
        }
    }
}
