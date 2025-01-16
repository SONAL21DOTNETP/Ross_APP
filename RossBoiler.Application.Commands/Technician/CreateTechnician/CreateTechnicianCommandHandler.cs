using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;

namespace RossBoiler.Application.Commands
{
    public class CreateTechnicianCommandHandler : IRequestHandler<CreateTechnicianCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateTechnicianCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTechnicianCommand request, CancellationToken cancellationToken)
        {
            var technician = new Technician
            {
                Name = request.Name,
                CompanyPhoneNumber = request.CompanyPhoneNumber,
                Age = request.Age,
                Qualification = request.Qualification,
                Experience = request.Experience,
                YearsWithRoss = request.YearsWithRoss,
                CTC = request.CTC,
                PostingLocation = request.PostingLocation,
                Aadhar = request.Aadhar,
                Pan = request.Pan,
                ResidentialAddress = request.ResidentialAddress,
                PersonalPhoneNumber = request.PersonalPhoneNumber
            };

            _context.Technicians.Add(technician);
            await _context.SaveChangesAsync(cancellationToken);

            return technician.Id;
        }
    }
}
