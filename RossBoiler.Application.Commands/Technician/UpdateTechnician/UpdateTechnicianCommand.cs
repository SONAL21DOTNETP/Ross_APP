using System.Net;
using MediatR;

namespace RossBoiler.Application.Commands
{
	public record UpdateTechnicianCommand(
		int TechnicianID,
		string Name,
		string CompanyPhoneNumber,
		int Age,
		string Qualification,
		int Experience,
		int YearsWithRoss,
		decimal CTC,
		string PostingLocation,
		string Aadhar,
		string Pan,
		string ResidentialAddress,
		string PersonalPhoneNumber
	) : IRequest<int>;
}
