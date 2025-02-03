using MediatR;
using Microsoft.EntityFrameworkCore;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Queries
{
    public class GetBoilerSeriesPartsMappingByIdQueryHandler : IRequestHandler<GetBoilerSeriesPartsMappingByIdQuery, BoilerSeriesPartsMapping>
    {
        private readonly ApplicationDbContext _context;

        public GetBoilerSeriesPartsMappingByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BoilerSeriesPartsMapping> Handle(GetBoilerSeriesPartsMappingByIdQuery request, CancellationToken cancellationToken)
        {
            var item= await _context.BoilerSeriesPartsMappings
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (item == null)
            {

                throw new KeyNotFoundException($"BoilerSeriesPartsMapping with ID {request.Id} not found");

            }
            return item;
        }
    }
}
