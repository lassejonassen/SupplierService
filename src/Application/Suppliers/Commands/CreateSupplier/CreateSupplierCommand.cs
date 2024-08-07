using SupplierService.Application.Abstractions.Messaging;

namespace SupplierService.Application.Suppliers.Commands.CreateSupplier;

public sealed record CreateSupplierCommand(
	string Name,
	string Street,
	string City,
	string PostalCode,
	string Country,
	string? State,
	string Email,
	string Phone,
	string? Notes) : ICommand<Guid>;
