using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.Contacts.Commands.UpdateContactVendorReference;

public sealed record UpdateContactVendorReferenceCommand(Guid ContactId, Guid SupplierId) : ICommand;
