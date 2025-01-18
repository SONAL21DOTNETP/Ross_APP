using MediatR;
using RossBoiler.Application.Data;
using RossBoiler.Application.Models;
using RossBoiler.Common;
using Microsoft.EntityFrameworkCore;

namespace RossBoiler.Application.Commands
{
	public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, string>
	{
		private readonly ApplicationDbContext _context;

		public DeleteAddressCommandHandler(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<string> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
		{
			var address = await _context.Addresses.FindAsync(new object[] { request.Id }, cancellationToken);
			if (address == null)
			{
				return $"Address with ID {request.Id} not found.";
			}

			_context.Addresses.Remove(address);
			await _context.SaveChangesAsync(cancellationToken);

			return $"Address with ID {request.Id} deleted successfully.";
		}
	}
}
