namespace SupplierService.Application.Contacts.Commands.DeleteContact;

public sealed record DeleteContactCommand(Guid Id) : ICommand;