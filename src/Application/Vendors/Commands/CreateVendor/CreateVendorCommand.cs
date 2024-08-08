namespace VendorService.Application.VendorService.Application.Vendors.Commands.CreateVendor;

public sealed record CreateVendorCommand(
	string Name,
	string Street,
	string City,
	string PostalCode,
	string Country,
	string? State,
	string Email,
	string Phone,
	string? Notes) : ICommand<Guid>;
