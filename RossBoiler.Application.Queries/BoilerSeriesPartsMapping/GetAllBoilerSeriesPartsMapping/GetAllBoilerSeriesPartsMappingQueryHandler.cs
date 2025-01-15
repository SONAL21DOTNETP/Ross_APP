using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetAllBoilerSeriesPartsMappingQueryHandler : IRequestHandler<GetAllBoilerSeriesPartsMappingQuery, List<BoilerSeriesPartsMapping>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllBoilerSeriesPartsMappingQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BoilerSeriesPartsMapping>> Handle(GetAllBoilerSeriesPartsMappingQuery request, CancellationToken cancellationToken)
        {
            return await _context.BoilerSeriesPartsMappings.ToListAsync(cancellationToken);
        }
    }
}
