using VendorService.Domain.Entities;

namespace VendorService.Application.Contacts.Commands.UpdateContact;

public sealed record UpdateContactCommand(Contact Contact) : ICommand;
