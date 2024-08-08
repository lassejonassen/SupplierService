namespace SupplierService.Application.Contacts.Commands.UpdateContact;

public sealed record UpdateContactCommand(Contact Contact) : ICommand;
