using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Contacts.Queries.GetContactById;

public sealed record GetContactByIdQuery(Guid Id) : IQuery<Contact>;
