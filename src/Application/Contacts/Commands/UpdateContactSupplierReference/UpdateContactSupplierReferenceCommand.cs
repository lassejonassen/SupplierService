namespace VendorService.Application.Contacts.Commands.UpdateContactSupplierReference;

public sealed record UpdateContactSupplierReferenceCommand(Guid ContactId, Guid SupplierId) : ICommand;
