namespace VendorService.Application.Contacts.Commands.CreateContact;

public sealed record CreateContactCommand(
	string FirstName, string LastName,
	string Email, string Phone,
	string? Notes,
	Guid SupplierId) : ICommand<Guid>;
