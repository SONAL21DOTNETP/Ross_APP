using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllBoilerSeriesQueryHandler : IRequestHandler<GetAllBoilerSeriesQuery, List<BoilerSeries>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllBoilerSeriesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BoilerSeries>> Handle(GetAllBoilerSeriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.BoilerSeries.ToListAsync(cancellationToken);
        }
    }
}
