using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.Contacts.Queries.GetContactBySupplierId;

public sealed record GetContactBySupplierIdQuery(Guid SupplierId) : IQuery<IEnumerable<Contact>>;
