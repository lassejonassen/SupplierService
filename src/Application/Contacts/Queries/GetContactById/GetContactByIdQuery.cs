using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.Contacts.Queries.GetContactById;

public sealed record GetContactByIdQuery(Guid Id) : IQuery<Contact>;
