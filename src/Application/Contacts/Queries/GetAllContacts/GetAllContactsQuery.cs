using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.Contacts.Queries.GetAllContacts;

public sealed record GetAllContactsQuery : IQuery<IEnumerable<Contact>>;
