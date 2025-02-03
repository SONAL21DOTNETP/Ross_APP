using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;

namespace RossBoiler.Application.Commands
{
    public class UpdateTechnicianCommandHandler : IRequestHandler<UpdateTechnicianCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateTechnicianCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateTechnicianCommand request, CancellationToken cancellationToken)
        {
            var technician = await _context.Technicians.FindAsync(new object[] { request.TechnicianID }, cancellationToken);

            if (technician == null)
                throw new KeyNotFoundException($"Technician with ID {request.TechnicianID} not found.");

            technician.Name = request.Name;
            technician.CompanyPhoneNumber = request.CompanyPhoneNumber;
            technician.Age = request.Age;
            technician.Qualification = request.Qualification;
            technician.Experience = request.Experience;
            technician.YearsWithRoss = request.YearsWithRoss;
            technician.CTC = request.CTC;
            technician.PostingLocation = request.PostingLocation;
            technician.Aadhar = request.Aadhar;
            technician.Pan = request.Pan;
            technician.ResidentialAddress = request.ResidentialAddress;
            technician.PersonalPhoneNumber = request.PersonalPhoneNumber;

            _context.Technicians.Update(technician);
            await _context.SaveChangesAsync(cancellationToken);

            return $"technician with ID {request.TechnicianID} updated successfully.";
        }
    }
}
