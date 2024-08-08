using SupplierService.Application.Abstractions.Messaging;

namespace SupplierService.Application.Contacts.Commands.CreateContact;

public sealed record CreateContactCommand(
	string FirstName, string LastName,
	string Email, string Phone,
	string? Notes, 
	Guid SupplierId) : ICommand<Guid>;
