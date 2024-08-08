using SupplierService.Application.Abstractions.Messaging;

namespace SupplierService.Application.Contacts.Commands.UpdateContactSupplierReference;

public sealed record UpdateContactSupplierReferenceCommand(Guid ContactId, Guid SupplierId) : ICommand;
