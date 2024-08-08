using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.Contacts.Commands.UpdateContact;

public sealed record UpdateContactCommand(Contact Contact) : ICommand;
