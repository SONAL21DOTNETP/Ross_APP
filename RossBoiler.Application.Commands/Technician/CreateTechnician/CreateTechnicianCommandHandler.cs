using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using System.Text.RegularExpressions;

namespace RossBoiler.Application.Commands
{
    public class CreateTechnicianCommandHandler : IRequestHandler<CreateTechnicianCommand, int>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICorrelationIdProvider _correlationIdProvider;
        public CreateTechnicianCommandHandler(ApplicationDbContext context, ICorrelationIdProvider correlationIdProvider)
        {
            _context = context;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task<int> Handle(CreateTechnicianCommand request, CancellationToken cancellationToken)
        {
            // Validate Name (Only alphabets and spaces allowed)
            if (!Regex.IsMatch(request.Name, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Name. Only alphabets and spaces are allowed.");
            }

            // Validate CompanyPhoneNumber (Phone number validation)
            if (!Regex.IsMatch(request.CompanyPhoneNumber, RegexConstants.PhoneNumberRegex))
            {
                throw new ArgumentException("Invalid Company Phone Number.");
            }

            // Validate PersonalPhoneNumber (Phone number validation)
            if (!Regex.IsMatch(request.PersonalPhoneNumber, RegexConstants.PhoneNumberRegex))
            {
                throw new ArgumentException("Invalid Personal Phone Number.");
            }

            // Validate Age (Age should be between 1 and 120)
            if (!Regex.IsMatch(request.Age.ToString(), RegexConstants.AgeRegex))
            {
                throw new ArgumentException("Invalid Age. Age must be between 1 and 120.");
            }

            // Validate Qualification (Only alphabets and spaces allowed)
            if (!Regex.IsMatch(request.Qualification, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Qualification. Only alphabets and spaces are allowed.");
            }

            // Validate Experience (Only numeric values allowed)
            if (!Regex.IsMatch(request.Experience.ToString(), RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid Experience. Only numeric values are allowed.");
            }

            // Validate YearsWithRoss (Only numeric values allowed)
            if (!Regex.IsMatch(request.YearsWithRoss.ToString(), RegexConstants.AlphanumericRegex))
            {
                throw new ArgumentException("Invalid YearsWithRoss. Only numeric values are allowed.");
            }

            // Validate CTC (Valid price format using regex)
            if (!Regex.IsMatch(request.CTC.ToString(), RegexConstants.PriceRegex))
            {
                throw new ArgumentException("Invalid CTC. It should be a valid price.");
            }

            // Validate PostingLocation (Only alphabets and spaces allowed)
            if (!Regex.IsMatch(request.PostingLocation, RegexConstants.AlphabeticRegex))
            {
                throw new ArgumentException("Invalid Posting Location. Only alphabets and spaces are allowed.");
            }

            // Validate Aadhar (Aadhar Card - 12 digit numeric)
            if (!Regex.IsMatch(request.Aadhar, RegexConstants.AadhaarCardRegex))
            {
                throw new ArgumentException("Invalid Aadhar number. It should be a 12-digit number.");
            }

            // Validate Pan (PAN Card - 10 alphanumeric characters)
            if (!Regex.IsMatch(request.Pan, RegexConstants.PanCardRegex))
            {
                throw new ArgumentException("Invalid PAN number.");
            }

            // Validate ResidentialAddress (Alphanumeric and basic special characters allowed)
            if (!Regex.IsMatch(request.ResidentialAddress, RegexConstants.AddressRegex))
            {
                throw new ArgumentException("Invalid Residential Address.");
            }

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
