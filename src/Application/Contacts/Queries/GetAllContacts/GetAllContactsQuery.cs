using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Contacts.Queries.GetAllContacts;

public sealed record GetAllContactsQuery : IQuery<IEnumerable<Contact>>;
